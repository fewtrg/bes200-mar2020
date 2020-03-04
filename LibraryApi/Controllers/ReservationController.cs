using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Domain;
using LibraryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    
    public class ReservationController : Controller
    {
        LibraryDataContext Context;

        public ReservationController(LibraryDataContext context)
        {
            Context = context;
        }
        [HttpGet("reservations")]
        public async Task<ActionResult> GetAllReservations()
        {
            var response = new HttpCollection<GetReservationItemResponse>();

            var data = await Context.Reservations.ToListAsync();
            response.Data = data.Select(r => MapIt(r)).ToList();
        }

       
    }

     private GetReservationItemResponse MapIt(Reservation r)
        {
            return new GetReservationItemResponse
            {
                Id = r.Id,
                For = r.For,
                ReservationCreated = r.ReservationCreated,
                Books = r.Books.Split(',')
                .Select(id => Url.ActionLink("books#getabook", "Books", new { id = id })).ToList(),
                Status = r.Status
            };
        } 
    }
