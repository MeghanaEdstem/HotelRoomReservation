using HotelRoomReservationApi.Models.Dto;

namespace HotelRoomReservationApi.Service
{
    public interface IRoomService
    {
        List<RoomDto> GetAvailableRooms(DateTime checkIn, DateTime checkOut, string roomType, decimal minPrice, decimal maxPrice);
        OccupancyReportDto GetOccupancyReport(string date);
    }
}
