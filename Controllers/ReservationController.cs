using HotelRoomReservationApi.Models.Dto;
using HotelRoomReservationApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomReservationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpPost]
        public IActionResult CreateReservation([FromBody] ReservationDto reservationDto)
        { 
            _reservationService.CreateReservation(reservationDto);
            return Ok();
        }
        [HttpPut("{id}/status")]
        public IActionResult UpdateReservationStatus(int id, [FromBody] string status)
        {
            _reservationService.UpdateReservationStatus(id, status);
            return Ok();
        }
    }
}
