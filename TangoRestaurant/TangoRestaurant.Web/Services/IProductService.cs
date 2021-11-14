using TangoRestaurant.Web.Models.Dto;

namespace TangoRestaurant.Web.Services
{
    public interface IProductService
    {
        Task<T> GetProductsAsync<T>(string token);
        Task<T> GetProductsByIdAsync<T>(int id, string token);
        Task<T> CreateProductAsync<T>(ProductDto productDto, string token);
        Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
