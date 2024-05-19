using AirGroup.Domain;
using AirGroup.Domain.Entity;
using AirGroup.Service.DTOS.ProductDto;
using AirGroup.Service.DTOS.ProductDtos;
using AirGroup.Service.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirGroup.Service.Services
{
    public class ProductService:IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(ProductCreateDto productDto)
        {
            var model = _mapper.Map<Product>(productDto);
            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
             _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var model = await _context.Products.ToListAsync();
            var res = _mapper.Map<List<ProductDto>>(model);
            return res;
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            var res = _mapper.Map<ProductDto>(product);
            return res;
        }

        public async Task UpdateAsync(ProductEditDto pro)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == pro.Id);

            _mapper.Map(pro, product);
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
