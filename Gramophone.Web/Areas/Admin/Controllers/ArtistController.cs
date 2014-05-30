using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gramophone.Web.Models;
using Gramophone.Web.Models.Services;

namespace Gramophone.Web.Areas.Admin.Controllers
{
    public class ArtistController : Controller
    {
        //
        // GET: /Admin/Artist/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddArtist() 
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult AddArtist(FormCollection frm)
        {
            ArtistDTO artist = new ArtistDTO();
            UpdateModel(artist);
            ArtistService artistService = new ArtistService();

            //Get Artists list
            artistService.AddArtist(artist);

            return RedirectToAction("AddArtist", "Artist", new { area = "Admin" });
        }
	}
}