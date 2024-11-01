using HotelRoomReservationApi.Models.Dto;
using HotelRoomReservationApi.Models.Entities;
using HotelRoomReservationApi.Repository;

namespace HotelRoomReservationApi.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public IEnumerable<RoomDto> GetAllRooms()
        {
            var rooms = _roomRepository.GetAllRooms();
            return rooms.Select(r => new RoomDto
            {
                RoomNumber = r.RoomNumber,
                Type = r.Type,
                PricePerNight = r.PricePerNight,
                Floor = r.Floor,
                Amenities = r.Amenities
            });
        }
        public RoomDto CreateRoom(CreateRoomDto roomDto)
        {
            var room = new Room
            {
                RoomNumber = roomDto.RoomNumber,
                Type = roomDto.Type,
                PricePerNight = roomDto.PricePerNight,
                Floor = roomDto.Floor,
                Amenities = roomDto.Amenities
            };
            var createdRoom = _roomRepository.CreateRoom(room);
            return new RoomDto
            {
                RoomNumber = createdRoom.RoomNumber,
                Type = createdRoom.Type,
                PricePerNight = createdRoom.PricePerNight,
                Floor = createdRoom.Floor,
                Amenities = createdRoom.Amenities
            };
        }
        public IEnumerable<RoomDto> GetAvailableRooms(DateTime checkIn, DateTime checkOut, string roomType, decimal minPrice, decimal maxPrice)
        {
            var rooms = _roomRepository.GetAvailableRooms(checkIn, checkOut, roomType, minPrice, maxPrice);
            return rooms.Select(r => new RoomDto
            {
                RoomNumber = r.RoomNumber,
                Type = r.Type,
                PricePerNight = r.PricePerNight,
                Floor = r.Floor,
                Amenities = r.Amenities
            });
        }
        public OccupancyReportDto GetOccupancyReport(string date)
        {
            // Implement logic to calculate occupancy report
            return new OccupancyReportDto
            {
                Date = date,
                OverallOccupancy = 75.5,
                ByRoomType = new Dictionary<string, double>
            {
                { "Single", 68.2 },
                { "Double", 82.4 },
                { "Suite", 70.0 }
            },
                Revenue = 28500.00m
            };
        }
    }
}
