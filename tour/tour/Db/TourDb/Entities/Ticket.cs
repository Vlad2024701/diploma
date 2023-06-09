﻿using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tour.Db.TourDb.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public virtual Tour? Tour { get; set; }
        //public int PlaceId { get; set; }
        //[ForeignKey("PlaceId")]
        //public virtual Place? Place { get; set; }
        public string? UserLogin { get; set; }
        [ForeignKey("Login")]
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
