using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gramophone.Web.Models;
using Gramophone.Web.Models.Services;

namespace Gramophone.Web.Areas.Admin.Controllers
{
    public class SongController : Controller
    {
        //
        // GET: /Admin/Song/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Song/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Song/Add
        public ActionResult Add()
        {
            SongService ss = new SongService();

            //Get Artists list
            List<ArtistDTO> artistList = ss.GetArtists();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var artist in artistList)
            {
                SelectListItem item = new SelectListItem { Text = artist.Name, Value = artist.ArtistID.ToString() };
                list.Add(item);
            }
            ViewBag.Singers = list;

            //Get Albums List
            List<Album> albums = ss.GetAlbums();
            List<SelectListItem> albumList = new List<SelectListItem>();
            foreach (var album in albums)
            {
                SelectListItem albumItem = new SelectListItem { Text = album.Name, Value = album.AlbumID.ToString() };
                albumList.Add(albumItem);
            }
            ViewBag.Albums = albumList;
            return View();
        }

        //
        // POST: /Admin/Song/Add
        [HttpPost]
        public ActionResult Add(FormCollection frm)
        {
            try
            {
                SongDTO songs=new SongDTO();
                UpdateModel(songs);

                SongService ss = new SongService();
                ss.AddSong(songs);
               // return View("~/Views/Admin/Song/Add");
                return RedirectToAction("Index");
            }
            catch
            {
               return View("~/Views/Admin/Song/Add");
            }
        }

        //
        // GET: /Admin/Song/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Song/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Song/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Song/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
