using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Domain.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public int ConsumerId { get; set; }
        public Consumer? Consumer { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
