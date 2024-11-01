using HotelRoomReservationApi.Models.Dto;

namespace HotelRoomReservationApi.Service
{
    public interface IRoomService
    {
        IEnumerable<RoomDto> GetAllRooms();
        RoomDto CreateRoom(CreateRoomDto roomDto);
        IEnumerable<RoomDto> GetAvailableRooms(DateTime checkIn, DateTime checkOut, string roomType, decimal minPrice, decimal maxPrice);
        OccupancyReportDto GetOccupancyReport(string date);
    }
}
