using System.Collections.Generic;
using PhotoAlbum.Models;

namespace PhotoAlbum.Services
{
    public interface IPhotoService
    {
        void CreatePhoto(Photo photo);
        void DeletePhoto(int id);
        void EditPhoto(Photo photo);
        Photo FindPhoto(int id);
        IList<Photo> ListPhotos(int id);
    }
}