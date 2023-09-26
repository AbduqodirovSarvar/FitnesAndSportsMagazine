using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Products.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Products.CommandHandlers
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
    {
        private readonly IAppDbContext context;
        public DeleteProductCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);
            if (product == null)
            {
                return false;
            }

            context.Products.Remove(product);
            return (await context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
