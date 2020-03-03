using LibraryApi.Models;
using System.Threading.Tasks;

namespace LibraryApi
{
    public interface IMapBooks
    {
        Task<GetABookResponse> GetBookById(int id);
    }
}