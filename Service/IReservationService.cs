using HotelRoomReservationApi.Models.Dto;

namespace HotelRoomReservationApi.Service
{
    public interface IReservationService
    {
        void CreateReservation(ReservationDto reservationDto);
        void UpdateReservationStatus(int id, string status);
    }
}
