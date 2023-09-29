using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Products.Queries;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Products.QueryHandlers
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetProductQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            return mapper.Map<ProductViewModel>(product);
        }
    }
}
