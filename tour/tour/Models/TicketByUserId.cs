using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using tour.Db.TourDb.Entities;

namespace tour.Models
{
    public class TicketByUserId
    {
        public int Id { get; set; }
        public string? TourName { get; set; }
        public List<int>? PlaceNumbers { get; set; }
        public DateTime TourTimeStart { get; set; }
        public DateTime TourTimeEnd { get; set; }

    }
}
