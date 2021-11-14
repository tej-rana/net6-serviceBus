using TangoRestaurant.Web.Models;
using TangoRestaurant.Web.Models.Dto;

namespace TangoRestaurant.Web.Services
{
    public interface IBaseService : IDisposable
    {
        ResponseDto ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
