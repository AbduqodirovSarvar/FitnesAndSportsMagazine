using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Products.Queries;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Products.QueryHandlers
{
    public class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, List<ProductViewModel>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        public GetAllProductQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await context.Products.Where(x => x.ProductType == request.GetProductType()).ToListAsync(cancellationToken);

            return mapper.Map<List<ProductViewModel>>(products);
        }
    }
}
