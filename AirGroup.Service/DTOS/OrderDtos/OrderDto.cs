using AirGroup.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirGroup.Service.DTOS.OrderDtos
{
    public class OrderDto
    {
        public int Id { get; set; }
     
        public string User { get; set; }
        public List<GetOrderItem> Products { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
