namespace HotelRoomReservationApi.Models.Dto
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public decimal PricePerNight { get; set; }
        public int Floor { get; set; }
        public List<string> Amenities { get; set; }
    }

}
