using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMqUtils;
using LibraryApi.Models;

namespace LibraryApi.Services
{
    public class RabbitMqReservationProcessor
    {
        IRabbitManager Manager;

        public RabbitMqReservationProcessor(IRabbitManager manager)
        {
            Manager = manager;
        }

        public void SendReservationForProcessing(GetReservationItemResponse reservation)
        {
            Manager.Publish(reservation, "", "direct", "reservations");

        }
    }
}
