using AutoMapper;
using LibraryApi.Domain;
using LibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, GetABookResponse>();
            CreateMap<Book, BookSummaryItem>();
            CreateMap<PostBooksRequest, Book>()
                .ForMember(dest => dest.Id,
                           opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => true));
        }

        private void CreateMap<T>()
        {
            throw new NotImplementedException();
        }
    }
}
