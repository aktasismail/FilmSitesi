﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{

    public record MovieDTO
    {
        public int Id { get; set; }
        public string? Moviename { get; set; }
        public string? MovieDetail { get; set; }
        public string? Cast { get; set; }
        public string? Director { get; set; }
        public string? Duration { get; set; }
        public int? Year { get; set; }
        public string? ImageUrl { get; set; }
        public string? MovieSource { get; set; }
        public decimal ImdbRate { get; set; }
        public int? GenreId { get; set; }

    }
}
