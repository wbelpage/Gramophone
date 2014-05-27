using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gramophone.Web.Models;

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
            return View();
        }

        //
        // POST: /Admin/Song/Add
        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            try
            {
                SongDTO songs=new SongDTO();
                UpdateModel(songs);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
