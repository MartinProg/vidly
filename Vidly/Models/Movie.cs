using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public Nullable<DateTime> AddedDate { get; set; }

        [Required]
        [Range (1,20)]
        [Display(Name = "Number In Stock")]
        public byte StockNumber { get; set; }

        //[Required]
        public Genre Genre { get; set; }

        [Display(Name="Genre")]
        public byte GenreId { get; set; }
    }
}