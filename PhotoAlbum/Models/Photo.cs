using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Models
{
    public enum Ratings
    {
        [Display(Name = "1 star")]  onestar,
        [Display(Name = "2 stars")] twostars,
        [Display(Name = "3 stars")] threestars,
        [Display(Name = "4 stars")] fourstars,
        [Display(Name = "5 stars")] fivestars

    }


    public class Photo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public Ratings Rating { get; set; }

        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }

        public string PhotoUrl { get; set; }
    }
}