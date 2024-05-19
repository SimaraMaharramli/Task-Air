using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirGroup.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<OrderItem> Products { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow.AddHours(4);
    }
}
