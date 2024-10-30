using HotelRoomReservationApi.Models.Dto;

namespace HotelRoomReservationApi.Service
{
    public interface IReservationService
    {
        bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut);
        void CreateReservation(ReservationDto reservationDto);
        bool UpdateReservationStatus(int id, string status);
    }
}
