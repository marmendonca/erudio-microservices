using AutoMapper;
using GeekShopping.ProductAPI.Infra.Repository.Interfaces;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Product.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();

                if (product == null) return false;

                _context.Product.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> FindAllAsync()
        {
            var products = await _context.Product.AsNoTracking().ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> FindById(long id)
        {
            var product = await _context.Product.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Save(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();

            return productDto;
        }

        public async Task<ProductDto> Update(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return productDto;
        }
    }
}
