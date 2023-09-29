using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Products.Commands;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Products.CommandHandlers
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, ProductViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly IFileSaveToFolder fileSaveToFolder;
        public UpdateProductCommandHandler(IAppDbContext context, IMapper mapper, IFileSaveToFolder fileSaveToFolder)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileSaveToFolder = fileSaveToFolder;
        }
        public async Task<ProductViewModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Name = request.Name ?? product.Name;
            product.Price = request.Price ?? product.Price;
            product.Description = request.Description ?? product.Description;
            product.Amount = request.Amount ?? product.Amount;
            product.Brand = request.Brand ?? product.Brand;
            product.Type = request.Type ?? product.Type;
            if (request.Image != null || request.Image?.Length > 0)
            {
                product.ImageName = await fileSaveToFolder.SaveToFolderAsync(request.Image);
            }

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<ProductViewModel>(product);
        }
    }
}
