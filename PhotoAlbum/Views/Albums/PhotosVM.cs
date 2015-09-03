using PhotoAlbum.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Views.Albums
{
    public class PhotosVM
    {
        public int AlbumId { get; set; }
        public Photo Photo { get; set; }

        public IList<Photo> Photos { get; set; }
    }
}