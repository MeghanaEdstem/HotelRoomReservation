using HotelRoomReservationApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using HotelRoomReservationApi.Service;
using Microsoft.EntityFrameworkCore;
using HotelRoomReservationApi.Models.Entities;
using HotelRoomReservationApi.Repository;


namespace HotelRoomReservationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("available")]
        public IActionResult GetAvailableRooms([FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut,
            [FromQuery] string roomType, [FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var availableRooms = _roomService.GetAvailableRooms(checkIn, checkOut, roomType, minPrice, maxPrice);
            return Ok(new { availableRooms });
        }

        [HttpGet("occupancy")]
        public IActionResult GetOccupancyReport([FromQuery] string date)
        {
            var report = _roomService.GetOccupancyReport(date);
            return Ok(report);
        }
        [HttpGet("all")]
        public IActionResult GetAllRooms()
        {
            var allRooms = _roomService.GetAllRooms();
            return Ok(allRooms);
        }
        [HttpPost]
        public IActionResult AddRooms(CreateRoomDto roomDto)
        {
            var createdRoom = _roomService.CreateRoom(roomDto);
            return Ok(createdRoom);
        }
    }
}
