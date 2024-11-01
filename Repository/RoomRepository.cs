using HotelRoomReservationApi.Data;
using HotelRoomReservationApi.Models.Entities;

namespace HotelRoomReservationApi.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RoomRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Room> GetAllRooms()
        {
            return _dbContext.Rooms.ToList();
        }
        public Room CreateRoom(Room room)
        {
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();
            return room;
        }
        public IEnumerable<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut, string roomType, decimal minPrice, decimal maxPrice)
        {
            return _dbContext.Rooms
                .Where(r => r.Type == roomType && r.PricePerNight >= minPrice && r.PricePerNight <= maxPrice)
                .Where(r => !_dbContext.Reservations.Any(res => res.RoomId == r.Id &&
                                                                ((res.CheckIn <= checkIn && res.CheckOut >= checkIn) ||
                                                                 (res.CheckIn <= checkOut && res.CheckOut >= checkOut))))
                .ToList();
        }
        public Room GetRoomById(int roomId)
        {
            return _dbContext.Rooms.Find(roomId);
        }
        public void UpdateRoom(Room room)
        {
            _dbContext.Rooms.Update(room);
            _dbContext.SaveChanges();
        }
    }

}
