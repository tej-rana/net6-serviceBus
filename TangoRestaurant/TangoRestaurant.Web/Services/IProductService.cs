using TangoRestaurant.Web.Models.Dto;

namespace TangoRestaurant.Web.Services
{
    public interface IProductService
    {
        Task<T> GetProductsAsync<T>();
        Task<T> GetProductsByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
