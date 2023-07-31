using System.Threading.Tasks;
using Refit;

namespace AcmeCorp.Domain.Services.Http
{
    public interface IFooClient
    {
        [Get("/")]
        Task<object> GetAll();
    }
}
