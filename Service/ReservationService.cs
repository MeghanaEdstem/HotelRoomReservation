using HotelRoomReservationApi.Models.Dto;
using HotelRoomReservationApi.Models.Entities;
using HotelRoomReservationApi.Repository;

namespace HotelRoomReservationApi.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        public ReservationService(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }
        public void CreateReservation(ReservationDto reservationDto)
        {
            if (reservationDto.CheckIn <= DateTime.Now)
            {
                throw new ArgumentException("Check-in date must be a future date.");
            }
            if ((reservationDto.CheckOut - reservationDto.CheckIn).TotalDays < 1)
            {
                throw new ArgumentException("Minimum stay is 1 day.");
            }
            if (!IsValidEmail(reservationDto.Email))
            {
                throw new ArgumentException("Invalid email format.");
            }
            var room = _roomRepository.GetRoomById(reservationDto.RoomId);
            if (room == null)
            {
                throw new ArgumentException("Room not found.");
            }
            var availableRooms = _roomRepository.GetAvailableRooms(reservationDto.CheckIn, reservationDto.CheckOut, room.Type, room.PricePerNight, room.PricePerNight);
            if (!availableRooms.Any(r => r.Id == reservationDto.RoomId))
            {
                throw new ArgumentException("Room is not available for the entire period.");
            }
            var reservation = new Reservation
            {
                RoomId = reservationDto.RoomId,
                GuestName = reservationDto.GuestName,
                Email = reservationDto.Email,
                CheckIn = reservationDto.CheckIn,
                CheckOut = reservationDto.CheckOut,
                Status = "Booked"
            };
            _reservationRepository.CreateReservation(reservation);
        }
        public void UpdateReservationStatus(int id, string status)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found.");
            }
            reservation.Status = status;
            _reservationRepository.UpdateReservation(reservation);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
