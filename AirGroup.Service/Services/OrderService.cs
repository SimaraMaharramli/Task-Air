using AirGroup.Domain.Entity;
using AirGroup.Domain;
using AirGroup.Service.DTOS.ProductDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirGroup.Service.Interfaces;
using AirGroup.Service.DTOS.OrderDtos;
using Microsoft.EntityFrameworkCore;
using AirGroup.Service.DTOS.ProductDto;

namespace AirGroup.Service.Services
{
    public class OrderService :IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OrderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(OrderCreateDto orderDto, string user)
        {
            var userid = _context.Users.FirstOrDefault(x => x.PhoneNumber == user).Id;
            List<OrderItem> items = new();
            if (orderDto.Products!=null)
            {
                foreach (var orderitem in orderDto.Products)
                {
                    OrderItem item = new OrderItem()
                    {
                        ProductId = orderitem.ProductId,
                    };
                    
                    items.Add(item);
                }
            }
            var model = new Order()
            {
                UserId=userid, 
                Description=orderDto.Description,
                Location=orderDto.Location,
                Products=items
            };

            await _context.Orders.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
        public async Task<List<OrderDto>> GetAllAsync()
        {
            var model = await _context.Orders.Include(x=>x.Products).ThenInclude(x=>x.Product).Select(x=>new OrderDto
            {
                Id = x.Id,
                Description=x.Description,
                Location = x.Location, 
                User=x.User.FullName,
                Products=x.Products.Select(x=> new GetOrderItem() {
                    Id = x.Product.Id,
                    Name=x.Product.Name, 
                    Price=x.Product.Price,
                    Stock=x.Product.Stock,
                    Description=x.Product.Description,
                }).ToList()
            }).ToListAsync();
            return model;
        }
        public async Task<List<OrderDto>> GetUserOrderHistoryAsync(string user)
        {
            var userid = _context.Users.FirstOrDefault(x => x.PhoneNumber == user).Id;
            var model = await _context.Orders.Where(x=>x.User.Id==userid).Select(x=>new OrderDto
            {
                Id = x.Id,
                Description=x.Description,
                Location = x.Location, 
                User=x.User.FullName,
                Products=x.Products.Select(x=> new GetOrderItem() {
                    Id = x.Product.Id,
                    Name=x.Product.Name, 
                    Price=x.Product.Price,
                    Stock=x.Product.Stock,
                    Description=x.Product.Description,
                }).ToList()
            }).ToListAsync();
            return model;
        }
    }
}
