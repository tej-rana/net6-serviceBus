using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TangoRestaurant.Services.ProductApi.Data.Models;
using TangoRestaurant.Services.ProductApi.Dto;

namespace TangoRestaurant.Services.ProductApi.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _dbContext.Products.Update(product);
            }
            else
            {
                _dbContext.Products.Add(product);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(productId);
                if (product == null)
                {
                    return false;
                }
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _dbContext.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
