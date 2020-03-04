using LibraryApi.Models;

namespace LibraryApi.Controllers
{
    internal interface ISendMessagesToTheReservationProcesser
    {
        void SendReservationForProcessing(GetReservationItemResponse response);
    }
}