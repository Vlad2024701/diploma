﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using tour.Db.TourDb.Entities;

namespace diploma.Db.Tour.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string? ImageURL { get; set; }
        public string? Name { get; set; }
        public int NumberOfGuests { get; set; }
        public string? HotelBuilding { get; set; }
        public string? WindowView { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        [JsonIgnore]
        public virtual Hotel? Hotel { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }
        public Room()
        {
            Tickets = new List<Ticket>();
        }
    }
}
