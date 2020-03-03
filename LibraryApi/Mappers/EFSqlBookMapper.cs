using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryApi.Domain;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Mappers
{
    public class EFSqlBookMapper : IMapBooks
    {
        LibraryDataContext Context;
        IMapper Mapper;

        public EFSqlBookMapper()
        {
            Context = context;
            Mapper = mapper;
        }

        public IQueryable<Book> GetBooksInInventory()
        {
            return Context.Books.Where(b => b.InInventory);
        }

        public async Task<GetABookResponse> GetABook(int id)
        {
            var response = await GetBooksInInventory()
                .Where(b => b.Id == id)
                .AsNoTracking()
                .Select(b => Mapper.Map<GetABookResponse>(b)).SingleOrDefaultAsync();
            return response;
        }

        public Task<GetABookResponse> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetBooksResponse> GetAllBooks(string genre)
        {
            var response = new GetBooksResponse();
            var data
        }
    }
}
