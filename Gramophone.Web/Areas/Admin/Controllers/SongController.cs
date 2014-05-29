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
        // GET: /Admin/AdminTask/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/AdminTask/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/AdminTask/AddSong
        public ActionResult AddSong()
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
        // POST: /Admin/AdminTask/AddSong
        [HttpPost]
        public ActionResult AddSong(FormCollection frm)
        {
            try
            {
                SongDTO song=new SongDTO();
                UpdateModel(song);

                SongService ss = new SongService();
                //ss.AddSong(song);
               // return View("~/Views/Admin/Song/Add");
                return RedirectToAction("AddSong", "Song", new { area = "Admin" });
            }
            catch
            {
                return RedirectToAction("AddSong", "Song", new { area = "Admin" });
            }
        }

        //
        // GET: /Admin/AdminTask/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/AdminTask/Edit/5
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
        // GET: /Admin/AdminTask/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/AdminTask/Delete/5
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
