using AdminServicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminServicios.Controllers.Catalogos
{
    public class ResidencialController : Controller
    {
        // GET: Residencial
        public ActionResult Index()
        {
            return View();
        }

        // GET: Residencial/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Editar = 1;
            using (var conex = new AdminServicios.DAL.Database1Entities())
            {
                var residencial = conex.CAT_RESIDENCIAL.Where(x => x.ID_RESIDENCIAL.Equals(id));
                return PartialView("~/Views/Residencial/Residencial.cshtml", residencial);
            }

        }

        

        // GET: Residencial/Create
        public ActionResult Create()
        {
            ViewBag.Editar = 0;
            DAL.CAT_RESIDENCIAL residencial = new DAL.CAT_RESIDENCIAL();
            return PartialView("~/Views/Residencial/Residencial.cshtml", residencial);
        }
        [HttpPost]
        public PartialViewResult Search()
        {
            using (var conex = new AdminServicios.DAL.Database1Entities())
            {
                var listResidencial = conex.CAT_RESIDENCIAL.ToList();
                return PartialView("~/Views/Residencial/GridResidencial.cshtml", listResidencial);
            }
        }

        // POST: Residencial/Create
        [HttpPost]
        public JsonResult Create(AdminServicios.DAL.CAT_RESIDENCIAL residencial)
        {
            Result resultado = new Result();
            try
            {
                // TODO: Add insert logic here
                using (var conex = new AdminServicios.DAL.Database1Entities())
                {
                    conex.CAT_RESIDENCIAL.Add(residencial);
                    conex.SaveChanges();
                    resultado.resultado = true;
                    resultado.mensajes.Add("Se agregó correctamente");
                }

            }
            catch(Exception ex)
            {
                resultado.resultado = false;
                resultado.mensajes.Add("Se generó un error al ingresar el registro");
            }
            return Json(resultado);
        }

        // GET: Residencial/Edit/5
        public ActionResult Edit(AdminServicios.DAL.CAT_RESIDENCIAL residencial)
        {
            Result resultado = new Result();
            try
            {
                // TODO: Add insert logic here
                using (var conex = new AdminServicios.DAL.Database1Entities())
                {
                    conex.SaveChanges();
                    resultado.resultado = true;
                    resultado.mensajes.Add("Se agregó correctamente");
                }

            }
            catch (Exception ex)
            {
                resultado.resultado = false;
                resultado.mensajes.Add("Se generó un error al ingresar el registro");
            }
            return Json(resultado);
        }

        // POST: Residencial/Edit/5
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

        // GET: Residencial/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Residencial/Delete/5
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
