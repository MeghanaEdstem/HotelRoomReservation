namespace HotelRoomReservationApi.Models.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public decimal PricePerNight { get; set; }
        public int Floor { get; set; }
        public List<string> Amenities { get; set; }
    }
}
