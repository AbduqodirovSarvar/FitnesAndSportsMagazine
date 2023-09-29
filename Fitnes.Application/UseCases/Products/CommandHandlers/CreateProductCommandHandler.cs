using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Products.Commands;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Products.CommandHandlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly IFileSaveToFolder fileSaveToFolder;
        public CreateProductCommandHandler(IAppDbContext context, IMapper mapper, IFileSaveToFolder fileSaveToFolder)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileSaveToFolder = fileSaveToFolder;
        }
        public async Task<ProductViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Name == request.Name && x.ProductType == request.GetProductType(), cancellationToken);
            if (product != null)
            {
                throw new Exception("Product already exists");
            }

            product = mapper.Map<Product>(request);

            if (request.Image != null || request.Image?.Length > 0)
            {
                product.ImageName = await fileSaveToFolder.SaveToFolderAsync(request.Image);
            }

            await context.Products.AddAsync(product, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<ProductViewModel>(product);
        }
    }
}
