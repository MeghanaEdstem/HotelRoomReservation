namespace HotelRoomReservationApi.Models.Dto
{
    public class ReservationDto
    {
        public int RoomId { get; set; }
        public string GuestName { get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

    }
}
