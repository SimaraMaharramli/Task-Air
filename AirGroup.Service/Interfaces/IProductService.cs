using AirGroup.Service.DTOS.ProductDto;
using AirGroup.Service.DTOS.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirGroup.Service.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreateDto productDto);

        Task UpdateAsync(ProductEditDto pro);
        Task DeleteAsync(int id);
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetAsync(int id);
    }
}
