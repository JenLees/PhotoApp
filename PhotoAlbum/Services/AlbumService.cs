using CoderCamps;
using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Services
{
    public class AlbumService : IAlbumService
    {
        private IGenericRepository _repo;

        public AlbumService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<Album> ListAllAlbums()
        {
            return _repo.Query<Album>().Include(a => a.Photos).ToList();
        }

        public IList<Album> ListUserAlbums(string userId)
        {
            return _repo.Query<Album>().Where(a => a.ApplicationUserId== userId).ToList();
        }

        public Album FindAlbum(int id)
        {
            return _repo.Find<Album>(id);
        }

        public void CreateAlbum(Album album)
        {
            _repo.Add<Album>(album);
            _repo.SaveChanges();
        }
         
        public void EditAlbum(Album album)
        {
            var original = this.FindAlbum(album.Id);
            original.Title = album.Title;
            original.Description = album.Description;
            _repo.SaveChanges();
        }

        public void DeleteAlbum(int id)
        {
            _repo.Delete<Album>(id);
            _repo.SaveChanges();
        }

    }
}