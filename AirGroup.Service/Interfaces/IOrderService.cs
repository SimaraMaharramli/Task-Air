﻿using AirGroup.Service.DTOS.OrderDtos;
using AirGroup.Service.DTOS.ProductDto;
using AirGroup.Service.DTOS.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirGroup.Service.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(OrderCreateDto orderDto,string userid);
        Task DeleteAsync(int id);
        Task<List<OrderDto>> GetAllAsync();
        Task<List<OrderDto>> GetUserOrderHistoryAsync(string user);
    }
}
