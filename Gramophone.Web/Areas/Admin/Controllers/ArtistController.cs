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

        public ActionResult AddArtist(int? id) 
        {
            if (id.HasValue)
            {
            ArtistService artistService = new ArtistService();
            ArtistDTO artist = artistService.GetById(id.Value);
            return View(artist);
            }
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

            return RedirectToAction("Artists", "Artist", new { area = "Admin" });
        }

        public ActionResult Artists()
        {
            ArtistService artistService = new ArtistService();
            IList<ArtistDTO> artistList = artistService.GetAll();

            return View(artistList);
        }
	}
}