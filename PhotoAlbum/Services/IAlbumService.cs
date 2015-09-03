using System.Collections.Generic;
using PhotoAlbum.Models;

namespace PhotoAlbum.Services
{
    public interface IAlbumService
    {
        void CreateAlbum(Album album);
        void DeleteAlbum(int id);
        void EditAlbum(Album album);
        Album FindAlbum(int id);
        IList<Album> ListAllAlbums();
        IList<Album> ListUserAlbums(string userId);
    }
}