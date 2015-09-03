using PhotoAlbum.Models;
using PhotoAlbum.Services;
using PhotoAlbum.Views.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoAlbum.Controllers
{
    public class AlbumsController : Controller
    {
        private IAlbumService _albumService;
        private IPhotoService _photoService;

        public AlbumsController(IAlbumService albumService, IPhotoService photoService)
        {
            _albumService = albumService;
            _photoService = photoService;
        }

        // GET: Albums
        public ActionResult Index()
        {
            var model = _albumService.ListAllAlbums();
            return View(model);

        }

      
        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            return View(_albumService.FindAlbum(id));
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(Album album)
        {
            if(ModelState.IsValid)
            {
                _albumService.CreateAlbum(album);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_albumService.FindAlbum(id));
        }

        // POST: Albums/Edit/5
        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _albumService.EditAlbum(album);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_albumService.FindAlbum(id));
        }

        // POST: Albums/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            _albumService.DeleteAlbum(id);
            return RedirectToAction("Index");
        }

        // ************************************************************************
        
        public ActionResult ViewPhotos(int id)
        {
            var vm = new PhotosVM()
            {
                AlbumId = id,
                Photo = new Photo(),
                Photos = _photoService.ListPhotos(id)
            };
            
            return View(vm);
        }


        // GET: Albums/CreatePhotos
        public ActionResult CreatePhoto(int id)
        {
            return View();
        }

        // POST: Albums/CreatePhotos
        [HttpPost]
        public ActionResult CreatePhoto(Photo photo, int id)
        {
            if (ModelState.IsValid)
            {
                photo.AlbumId = id;
                _photoService.CreatePhoto(photo);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult EditPhoto(int id)
        {
            var original = _photoService.FindPhoto(id);
            return View(original);
        }

        [HttpPost]
        public ActionResult EditPhoto(Photo photo)
        {
            if (ModelState.IsValid)
            {
                _photoService.EditPhoto(photo);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeletePhoto(int id)
        {
            var original = _photoService.FindPhoto(id);
            return View(original);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePhotoReally(int id)
        {
            _photoService.DeletePhoto(id);
            return RedirectToAction("Index");
        }

    }
}
