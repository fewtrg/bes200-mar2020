using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Domain;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Mappers
{
    public class EFSqlBookMapper : IMapBooks
    {
        LibraryDataContext Context;

        public IQueryable<Book> GetBooksInInventory()
        {
            return Context.Books.Where(b => b.InInventory);
        }

        public async Task<GetABookResponse> GetABook(int id)
        {
            var response = await GetBooksInInventory()
                .Where(b => b.Id == id)
                .Select(b => new GetABookResponse
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    NumberOfPages = b.NumberOfPages
                }).SingleOrDefaultAsync();
            return response;
        }

        public Task<GetABookResponse> GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
