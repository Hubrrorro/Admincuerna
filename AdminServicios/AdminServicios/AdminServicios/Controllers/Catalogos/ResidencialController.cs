using AdminServicios.Models;
using AdminServicios.Models.Catalogos;
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
        public ActionResult Details(int id_Residencial)
        {
            ViewBag.Editar = 1;
            using (var conex = new AdminServicios.DAL.Database1Entities())
            {
                var residencial = conex.CAT_RESIDENCIAL.Where(x => x.ID_RESIDENCIAL.Equals(id_Residencial)).FirstOrDefault(); ;
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
        public PartialViewResult SearchResidencial(string nombre)
        {
            using (var conex = new AdminServicios.DAL.Database1Entities())
            {
                var listResidencial = conex.CAT_RESIDENCIAL.Where(x => x.RESIDENCIAL.Contains(nombre)).ToList();
                return PartialView("~/Views/Residencial/GridResidencial.cshtml", listResidencial);
            }
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
        public JsonResult Create(Residencial residencialModel)
        {
            Result resultado = new Result();
            try
            {
                // TODO: Add insert logic here
                using (var conex = new AdminServicios.DAL.Database1Entities())
                {
                    var existe = conex.CAT_RESIDENCIAL.Where(x => x.RESIDENCIAL.Trim().ToUpper().Equals(residencialModel.RESIDENCIAL.Trim().ToUpper())).Count();
                    if (existe > 0)
                    {
                        resultado.resultado = false;
                        resultado.mensajes.Add("Ya se cuenta con un nombre identico");
                    }
                    else
                    {
                        AdminServicios.DAL.CAT_RESIDENCIAL residencial = new DAL.CAT_RESIDENCIAL();
                        residencial.RESIDENCIAL = residencialModel.RESIDENCIAL;
                        residencial.ABREVIATURA = residencialModel.ABREVIATURA;
                        residencial.ACTIVO = true;
                        conex.CAT_RESIDENCIAL.Add(residencial);
                        conex.SaveChanges();
                        resultado.resultado = true;
                        resultado.mensajes.Add("Se agregó correctamente");
                    }
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
        [HttpPost]
        public JsonResult Edit(Residencial residencialModel)
        {
            Result resultado = new Result();
            try
            {
                // TODO: Add insert logic here
                using (var conex = new AdminServicios.DAL.Database1Entities())
                {
                    var rowEdit = conex.CAT_RESIDENCIAL.Where(x => x.ID_RESIDENCIAL.Equals(residencialModel.ID_RESIDENCIAL)).FirstOrDefault();
                    rowEdit.ABREVIATURA = residencialModel.ABREVIATURA;
                    rowEdit.ACTIVO = residencialModel.ACTIVO;
                    rowEdit.RESIDENCIAL = residencialModel.RESIDENCIAL;
                    conex.SaveChanges();
                    resultado.resultado = true;
                    resultado.mensajes.Add("Se modificó correctamente");
                }

            }
            catch (Exception ex)
            {
                resultado.resultado = false;
                resultado.mensajes.Add("Se generó un error al ingresar el registro");
            }
            return Json(resultado);
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
