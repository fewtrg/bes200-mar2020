using LibraryApi.Domain;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class BooksController : Controller
    {
       // LibraryDataContext Context;
        IMapBooks Mapper;

        public BooksController(IMapBooks mapper)  {
            Mapper = mapper;
        }


        [HttpPut("books/{id:int}/numberofpages")]
        public async Task<ActionResult> UpdateNumberOfPages(int id, [FromBody] int newPages)
        {
            bool didUpdate = await Mapper.UpdateNumberOfPages(
                id, newPages);
            return this.Either<NoContentResult, NotFoundResult;
                

        }

        [HttpDelete("books/{id:int}")]
        public async Task<ActionResult> RemoveABook(int id)
        {
            await Mapper.Remove(id);
            return NoContent();
        }


        /// <summary>
        /// Add a Book To The Inventory
        /// </summary>
        /// <param name="bookToAdd">The details of the book to add</param>
        /// <returns></returns>
        [HttpPost("books")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetABookResponse>> AddABook([FromBody] PostBooksRequest bookToAdd)
        {
            GetABookResponse response = await Mapper.AddABook(bookToAdd);
            return CreatedAtRoute("books#getabook", new { id = response.Id }, response);
        }


        [HttpGet("books/{id:int}", Name ="books#getabook")]
        public async Task<ActionResult<GetABookResponse>> GetABook(int id)
        {
            /*var response = await GetBooksInInventory()
                .Where(b => b.Id == id)
                .Select(b => new GetABookResponse
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    NumberOfPages = b.NumberOfPages
                }).SingleOrDefaultAsync();*/

            GetABookResponse response = await Mapper.GetBookById(id);


            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }


        }

        [HttpGet("books")]
        public async Task<ActionResult<GetBooksResponse>> GetAllBooks([FromQuery] string genre = "all")
        {

            GetBooksResponse response = await Mapper.GetAllBooks(genre);
           /* var response = new GetBooksResponse();
            var data = GetBooksInInventory();

            if(genre != "all")
            {
                data = data.Where(b => b.Genre == genre);
            }
              response.Data = await data.Select(b => new BookSummaryItem {  Id = b.Id, Title=b.Title, Author = b.Author})
                .ToListAsync();
            response.Genre = genre;
            return Ok(response);*/
        }

       
        private IQueryable<Book> GetBooksInInventory()
        {
            return Context.Books.Where(b => b.InInventory);
        }
    }
}
