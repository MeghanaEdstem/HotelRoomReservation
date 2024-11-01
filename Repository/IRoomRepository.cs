using HotelRoomReservationApi.Models.Entities;

namespace HotelRoomReservationApi.Repository
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAllRooms();
        Room CreateRoom(Room room);
        IEnumerable<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut, string roomType, decimal minPrice, decimal maxPrice);
        Room GetRoomById(int roomId);
        void UpdateRoom(Room room);
    }

}
