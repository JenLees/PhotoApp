using CoderCamps;
using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Services
{
    public class PhotoService : IPhotoService
    {
        private IGenericRepository _repo;

        public PhotoService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<Photo> ListPhotos (int id)
        {
            return _repo.Query<Photo>().Where(p => p.AlbumId == id).ToList();
        }

        public Photo FindPhoto (int id)
        {
            return _repo.Find<Photo>(id);
        }

        public void EditPhoto(Photo photo)
        {
            var original = this.FindPhoto(photo.Id);
            original.Title = photo.Title;
            original.Description = photo.Description;
            original.Rating = photo.Rating;
            original.PhotoUrl = photo.PhotoUrl;
            _repo.SaveChanges();
        }

        public void CreatePhoto (Photo photo)
        {
            _repo.Add<Photo>(photo);
            _repo.SaveChanges();
        }

        public void DeletePhoto (int id)
        {
            _repo.Delete<Photo>(id);
            _repo.SaveChanges();
        }

    }
}