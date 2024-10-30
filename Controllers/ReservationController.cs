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
            if (reservationDto.CheckIn <= DateTime.Now)
            {
                return BadRequest("Check-in date must be a future date.");
            }
            if ((reservationDto.CheckOut - reservationDto.CheckIn).TotalDays < 1)
            {
                return BadRequest("Minimum stay is 1 day.");
            }
            if (!IsValidEmail(reservationDto.Email))
            {
                return BadRequest("Invalid email format.");
            }
            if (!_reservationService.IsRoomAvailable(reservationDto.RoomId, reservationDto.CheckIn, reservationDto.CheckOut))
            {
                return BadRequest("Room is not available for the entire period.");
            }
            _reservationService.CreateReservation(reservationDto);
            return Ok();
        }
        [HttpPut("{id}/status")]
        public IActionResult UpdateReservationStatus(int id, [FromBody] string status)
        {
            var result = _reservationService.UpdateReservationStatus(id, status);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
