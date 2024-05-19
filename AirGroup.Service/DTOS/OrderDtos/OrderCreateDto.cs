using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirGroup.Service.DTOS.OrderDtos
{
    public class OrderCreateDto
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public List<OrderItemDto> Products { get; set; }
    }
}
