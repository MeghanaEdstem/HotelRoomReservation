using HotelRoomReservationApi.Models.Entities;

namespace HotelRoomReservationApi.Repository
{
    public interface IReservationRepository
    {
        void CreateReservation(Reservation reservation);
        Reservation GetReservationById(int id);
        void UpdateReservation(Reservation reservation);
    }
}
