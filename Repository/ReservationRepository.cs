using HotelRoomReservationApi.Data;
using HotelRoomReservationApi.Models.Entities;

namespace HotelRoomReservationApi.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateReservation(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
        }
        public Reservation GetReservationById(int id)
        {
            return _dbContext.Reservations.Find(id);
        }
        public void UpdateReservation(Reservation reservation)
        {
            _dbContext.Reservations.Update(reservation);
            _dbContext.SaveChanges();
        }
    }
}
