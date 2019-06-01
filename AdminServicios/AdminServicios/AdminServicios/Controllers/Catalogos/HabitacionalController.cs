using AdminServicios.Models;
using AdminServicios.Models.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminServicios.Controllers.Catalogos
{
    public class HabitacionalController : Controller
    {
        // GET: Residencial
        public ActionResult Index()
        {
            return View();
        }

        // GET: Residencial/Details/5
        public ActionResult Details(int id_Habitacional)
        {
            ViewBag.Editar = 1;
            using (var conex = new AdminServicios.DAL.Database1Entities())
            {
                var residencial = conex.CAT_HABITACIONAL.Where(x => x.Id_HABITACIONAL.Equals(id_Habitacional)).FirstOrDefault(); ;
                return PartialView("~/Views/Habitacional/Habitacional.cshtml", residencial);
            }

        }
        // GET: Residencial/Create
        public ActionResult Create()
        {
            ViewBag.Editar = 0;
            DAL.CAT_HABITACIONAL residencial = new DAL.CAT_HABITACIONAL();
            return PartialView("~/Views/Habitacional/Habitacional.cshtml", residencial);
        }
        [HttpPost]
        public PartialViewResult SearchHabitacional(HabitacionalModel habitacionalModel)
        {
            using (var conex = new AdminServicios.DAL.Database1Entities())
            {
                var listHabitacional = (from hab in conex.CAT_HABITACIONAL
                                        join res in conex.CAT_RESIDENCIAL on hab.ID_RESIDENCIAL equals res.ID_RESIDENCIAL
                                        select new
                                        {
                                            RESIDENCIAL = res.RESIDENCIAL,
                                            HABITACIONAL = hab.HABITACIONAL,
                                            Activo = hab.ACTIVO,
                                            ID_HABITACIONAL = hab.Id_HABITACIONAL,
                                            ID_RESIDENCIAL = res.ID_RESIDENCIAL
                                        }).ToList();
                if (!habitacionalModel.ID_RESIDENCIAL.Equals(0))
                    listHabitacional = listHabitacional.Where(x => x.ID_RESIDENCIAL.Equals(habitacionalModel.ID_RESIDENCIAL)).ToList();
                if (!String.IsNullOrEmpty(habitacionalModel.HABITACIONAL))
                    listHabitacional = listHabitacional.Where(x => x.HABITACIONAL.Contains(habitacionalModel.HABITACIONAL)).ToList();

                List<HabitacionalModel> listModel = new List<HabitacionalModel>();
                foreach (var item in listHabitacional)
                {
                    HabitacionalModel itemModel = new HabitacionalModel()
                    {
                        ACTIVO = item.Activo,
                        HABITACIONAL = item.HABITACIONAL,
                        ID_HABITACIONAL = item.ID_HABITACIONAL,
                        ID_RESIDENCIAL = item.ID_RESIDENCIAL,
                        RESIDENCIAL = item.RESIDENCIAL
                    };
                    listModel.Add(itemModel);
                }
                return PartialView("~/Views/Habitacional/GridHabitacional.cshtml", listModel);
            }
        }
        [HttpPost]
        public PartialViewResult Search()
        {
            using (var conex = new AdminServicios.DAL.Database1Entities())
            {
                List<HabitacionalModel> listModel = new List<HabitacionalModel>();
                //var listHabitacional = conex.CAT_HABITACIONAL.ToList();
                var listHabitacional = (from hab in conex.CAT_HABITACIONAL
                                        join res in conex.CAT_RESIDENCIAL on hab.ID_RESIDENCIAL equals res.ID_RESIDENCIAL
                                        select new
                                        {
                                            RESIDENCIAL = res.RESIDENCIAL,
                                            HABITACIONAL = hab.HABITACIONAL,
                                            Activo = hab.ACTIVO,
                                            ID_HABITACIONAL = hab.Id_HABITACIONAL,
                                            ID_RESIDENCIAL = res.ID_RESIDENCIAL
                                        }).ToList();
                foreach (var item in listHabitacional)
                {
                    HabitacionalModel itemModel = new HabitacionalModel() {
                         ACTIVO= item.Activo,
                          HABITACIONAL = item.HABITACIONAL,
                           ID_HABITACIONAL = item.ID_HABITACIONAL,
                            ID_RESIDENCIAL = item.ID_RESIDENCIAL,
                             RESIDENCIAL = item.RESIDENCIAL
                    };
                    listModel.Add(itemModel);
                }
                return PartialView("~/Views/Habitacional/GridHabitacional.cshtml", listModel);
            }
        }
        [HttpPost]
        public ActionResult ObtenerResidencial()
        {
            Result resultado = new Result();
            List<ResidencialModel> residencialMList = new List<ResidencialModel>();
            try
            {
                using (var conex2 = new AdminServicios.DAL.Database1Entities())
                {
                     var residencialList = conex2.CAT_RESIDENCIAL.Where(x => x.ACTIVO.Equals(true)).ToList();
                    foreach (var residencial in residencialList)
                    {
                        ResidencialModel item = new ResidencialModel() {
                             ID_RESIDENCIAL = residencial.ID_RESIDENCIAL,
                             RESIDENCIAL = residencial.RESIDENCIAL
                        };
                        residencialMList.Add(item);
                    }
                    resultado.resultado = true;
                    resultado.datos = residencialMList;
                    conex2.Dispose();
                    return Json(resultado);
                }
            }
            catch (Exception ex)
            {
                resultado.resultado = false;
                resultado.mensajes.Add("No se pudo obtener el catalogo de residenciales");
            }
            return Json(resultado);
        }
        // POST: Residencial/Create
        [HttpPost]
        public JsonResult Create(HabitacionalModel habitacionalModel)
        {
            Result resultado = new Result();
            try
            {
                if (habitacionalModel.ID_RESIDENCIAL.Equals(0))
                {
                    resultado.resultado = false;
                    resultado.mensajes.Add("Se generó un error al ingresar el registro");
                    return Json(resultado);
                }
                // TODO: Add insert logic here
                using (var conex = new AdminServicios.DAL.Database1Entities())
                {
                    var existe = conex.CAT_HABITACIONAL.Where(x => x.HABITACIONAL.Trim().ToUpper().Equals(habitacionalModel.HABITACIONAL.Trim().ToUpper())).Count();
                    if (existe > 0)
                    {
                        resultado.resultado = false;
                        resultado.mensajes.Add("Ya se cuenta con un nombre identico");
                    }
                    else
                    {
                        AdminServicios.DAL.CAT_HABITACIONAL habitacional = new DAL.CAT_HABITACIONAL();
                        habitacional.ACTIVO = true;
                        habitacional.HABITACIONAL = habitacionalModel.HABITACIONAL;
                        habitacional.ID_RESIDENCIAL = habitacionalModel.ID_RESIDENCIAL;
                        conex.CAT_HABITACIONAL.Add(habitacional);
                        conex.SaveChanges();
                        resultado.resultado = true;
                        resultado.mensajes.Add("Se agregó correctamente");
                    }
                }

            }
            catch (Exception ex)
            {
                resultado.resultado = false;
                resultado.mensajes.Add("Se generó un error al ingresar el registro");
            }
            return Json(resultado);
        }

        // GET: Residencial/Edit/5
        [HttpPost]
        public JsonResult Edit(HabitacionalModel habitacionalModel)
        {
            Result resultado = new Result();
            try
            {
                // TODO: Add insert logic here
                using (var conex = new AdminServicios.DAL.Database1Entities())
                {
                    var rowEdit = conex.CAT_HABITACIONAL.Where(x => x.Id_HABITACIONAL.Equals(habitacionalModel.ID_HABITACIONAL)).FirstOrDefault();
                    
                    rowEdit.ACTIVO = habitacionalModel.ACTIVO;
                    rowEdit.HABITACIONAL = habitacionalModel.HABITACIONAL;
                    rowEdit.ID_RESIDENCIAL = habitacionalModel.ID_RESIDENCIAL;
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
