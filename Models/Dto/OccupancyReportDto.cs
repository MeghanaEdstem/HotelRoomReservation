namespace HotelRoomReservationApi.Models.Dto
{
    public class OccupancyReportDto
    {
        public string Date { get; set; }
        public double OverallOccupancy { get; set; }
        public Dictionary<string, double> ByRoomType { get; set; }
        public decimal Revenue { get; set; }
    }
}
