using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminServicios.Controllers.Trabajos
{
    public class TrabajosController : Controller
    {
        // GET: Trabajos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Trabajos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trabajos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trabajos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trabajos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trabajos/Edit/5
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

        // GET: Trabajos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trabajos/Delete/5
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
