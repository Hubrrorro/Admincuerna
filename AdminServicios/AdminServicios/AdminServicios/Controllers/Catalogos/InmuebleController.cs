using AdminServicios.Models;
using AdminServicios.Models.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminServicios.Controllers.Catalogos
{
    public class InmuebleController : Controller
    {
        // GET: Inmueble
        public ActionResult Index()
        {
            return View();
        }
        // GET: Residencial/Details/5
        public ActionResult Details(int id_Inmueble)
        {
            ViewBag.Editar = 1;
            using (var conex = new AdminServicios.DAL.Database1Entities())
            {
                var listbd = conex.CAT_INMUEBLES.ToList();
                var inmueblebd = conex.CAT_INMUEBLES.Where(x => x.ID_INMUEBLE.Equals(id_Inmueble)).FirstOrDefault();
                var habitacionalbd = conex.CAT_HABITACIONAL.Where(x => x.Id_HABITACIONAL.Equals(inmueblebd.ID_HABITACIONAL)).FirstOrDefault();
                InmuebleModel inmueble = new InmuebleModel() {
                     Activo = inmueblebd.ACTIVO ? 1: 0,
                     Email = inmueblebd.EMAIL,
                     Id_Habitacional = inmueblebd.ID_HABITACIONAL,
                     Id_Inmueble = inmueblebd.ID_INMUEBLE,
                     NumExt = inmueblebd.NUMEXT,
                     NumInt = inmueblebd.NUMINT,
                     Propietario = inmueblebd.PROPIETARIO,
                     Id_Residencial = habitacionalbd.ID_RESIDENCIAL
                };
                return PartialView("~/Views/Inmueble/Inmueble.cshtml", inmueble);
            }

        }
        // GET: Residencial/Create
        public ActionResult Create()
        {
            ViewBag.Editar = 0;
            InmuebleModel inmueble = new InmuebleModel() {  Activo = 1, Id_Habitacional=0, Id_Residencial= 0, Id_Inmueble= 0};
            return PartialView("~/Views/Inmueble/Inmueble.cshtml", inmueble);
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
                        ResidencialModel item = new ResidencialModel()
                        {
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
        [HttpPost]
        public ActionResult ObtenerHabitacional(int id_Residencial)
        {
            Result resultado = new Result();
            List<HabitacionalModel> HabitacionalMList = new List<HabitacionalModel>();
            try
            {
                using (var conex2 = new AdminServicios.DAL.Database1Entities())
                {
                    var habitacionalList = conex2.CAT_HABITACIONAL.Where(x => x.ACTIVO.Equals(true) && x.ID_RESIDENCIAL.Equals(id_Residencial)).ToList();
                    foreach (var habitacional in habitacionalList)
                    {
                        HabitacionalModel item = new HabitacionalModel()
                        {
                            ID_HABITACIONAL = habitacional.Id_HABITACIONAL,
                            HABITACIONAL = habitacional.HABITACIONAL
                        };
                        HabitacionalMList.Add(item);
                    }
                    resultado.resultado = true;
                    resultado.datos = HabitacionalMList;
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
        [HttpPost]
        public ActionResult Obtener(InmuebleModel model)
        {
            Result resultado = new Result();
            List<InmuebleModel> inmuebleMList = new List<InmuebleModel>();
            try
            {
                using (var conex2 = new AdminServicios.DAL.Database1Entities())
                {
                    var inmuebleList = (from i in conex2.CAT_INMUEBLES
                                        join h in conex2.CAT_HABITACIONAL on i.ID_HABITACIONAL equals h.Id_HABITACIONAL
                                        join r in conex2.CAT_RESIDENCIAL on h.ID_RESIDENCIAL equals r.ID_RESIDENCIAL
                                        select new
                                        {
                                            id_Residencial = r.ID_RESIDENCIAL,
                                            residencial = r.RESIDENCIAL,
                                            id_Habitacional = h.Id_HABITACIONAL,
                                            habitacional = h.HABITACIONAL,
                                            id_Inmueble = i.ID_INMUEBLE,
                                            numInt = i.NUMINT,
                                            numExt = i.NUMEXT,
                                            activo = i.ACTIVO,
                                            email = i.EMAIL,
                                            propietario = i.PROPIETARIO
                                        }).ToList();
                    //if (model.Activo >= 0)
                    //{
                    //    bool activo = model.Activo.Equals(1) ? true : false;
                    //    inmuebleList = inmuebleList.Where(x => x.activo.Equals(activo)).ToList();
                    //}
                    if (model.Id_Habitacional > 0)
                        inmuebleList = inmuebleList.Where(x => x.id_Habitacional.Equals(model.Id_Habitacional)).ToList();
                    if (model.Id_Residencial > 0)
                        inmuebleList = inmuebleList.Where(x => x.id_Residencial.Equals(model.Id_Residencial)).ToList();
                    if (model.Id_Inmueble > 0)
                        inmuebleList = inmuebleList.Where(x => x.id_Inmueble.Equals(model.Id_Inmueble)).ToList();
                    if (String.IsNullOrEmpty(model.Propietario))
                        inmuebleList = inmuebleList.Where(x => x.propietario.Contains(model.Propietario)).ToList();

                    foreach (var inmueble in inmuebleList)
                    {
                        InmuebleModel item = new InmuebleModel()
                        {
                            Id_Residencial = inmueble.id_Residencial,
                            Id_Habitacional = inmueble.id_Habitacional,
                            Id_Inmueble = inmueble.id_Inmueble,
                            Residencial = inmueble.residencial,
                            Habitacional = inmueble.habitacional,
                            NumInt = inmueble.numInt,
                            NumExt = inmueble.numExt,
                            Activo = inmueble.activo ? 1 : 0,
                            Email = inmueble.email,
                            Propietario = inmueble.propietario
                        };
                        inmuebleMList.Add(item);
                    }
                    resultado.resultado = true;
                    resultado.datos = inmuebleMList;
                    conex2.Dispose();
                    //return Json(resultado);
                }
            }
            catch (Exception ex)
            {
                resultado.resultado = false;
                resultado.mensajes.Add("No se pudo obtener el catalogo de residenciales");
            }
            return PartialView("~/Views/Inmueble/GridInmueble.cshtml", inmuebleMList);
            //return Json(resultado);
            
        }
        [HttpPost]
        public ActionResult ObtenerInmueble()
        {
            Result resultado = new Result();
            List<InmuebleModel> inmuebleMList = new List<InmuebleModel>();
            try
            {
                using (var conex2 = new AdminServicios.DAL.Database1Entities())
                {
                    var inmuebleList = (from i in conex2.CAT_INMUEBLES
                                        join h in conex2.CAT_HABITACIONAL on i.ID_HABITACIONAL equals h.Id_HABITACIONAL
                                        join r in conex2.CAT_RESIDENCIAL on h.ID_RESIDENCIAL equals r.ID_RESIDENCIAL
                                        select new
                                        {
                                            id_Residencial = r.ID_RESIDENCIAL,
                                            residencial = r.RESIDENCIAL,
                                            id_Habitacional = h.Id_HABITACIONAL,
                                            habitacional = h.HABITACIONAL,
                                            id_Inmueble = i.ID_INMUEBLE,
                                            numInt = i.NUMINT,
                                            numExt = i.NUMEXT,
                                            activo = i.ACTIVO,
                                            email = i.EMAIL,
                                            propietario = i.PROPIETARIO
                                        }).ToList();
                                       
                    foreach (var inmueble in inmuebleList)
                    {
                        InmuebleModel item = new InmuebleModel()
                        {
                            Id_Residencial = inmueble.id_Residencial,
                            Id_Habitacional = inmueble.id_Habitacional,
                            Residencial = inmueble.residencial,
                            Habitacional = inmueble.habitacional,
                            Id_Inmueble = inmueble.id_Inmueble,
                            NumInt = inmueble.numInt,
                            NumExt = inmueble.numExt,
                            Activo = inmueble.activo ? 1 : 0,
                            Email = inmueble.email,
                            Propietario = inmueble.propietario
                        };
                        inmuebleMList.Add(item);
                    }
                    resultado.resultado = true;
                    resultado.datos = inmuebleMList;
                    conex2.Dispose();
                    //return Json(resultado);
                }
            }
            catch (Exception ex)
            {
                resultado.resultado = false;
                resultado.mensajes.Add("No se pudo obtener el catalogo de residenciales");
            }
            //return Json(resultado);
            return PartialView("~/Views/Inmueble/GridInmueble.cshtml", inmuebleMList);
        }
        [HttpPost]
        public ActionResult Create(InmuebleModel inmueble)
        {
            Result resultado = new Result();
            try
            {
                // TODO: Add insert logic here
                using (var conex = new AdminServicios.DAL.Database1Entities())
                {
                    var listadoInmueble = conex.CAT_INMUEBLES.Where(x => x.NUMEXT.Trim().ToUpper().Equals(inmueble.NumExt)).ToList();
                    if (!String.IsNullOrEmpty(inmueble.NumInt))
                    {
                        listadoInmueble = listadoInmueble.Where(x => x.NUMINT.Trim().ToUpper().Equals(inmueble.NumInt)).ToList();
                    }
                    var existe = listadoInmueble.Count();
                    if (existe > 0)
                    {
                        resultado.resultado = false;
                        resultado.mensajes.Add("Ya se cuenta con un inmueble identico");
                    }
                    else
                    {
                        AdminServicios.DAL.CAT_INMUEBLES newinmueble = new DAL.CAT_INMUEBLES() {
                             ACTIVO= true,
                             ID_HABITACIONAL = inmueble.Id_Habitacional,
                             NUMEXT = inmueble.NumExt,
                             EMAIL = inmueble.Email,
                              NUMINT = inmueble.NumInt,
                               PROPIETARIO = inmueble.Propietario
                        };
                        conex.CAT_INMUEBLES.Add(newinmueble);
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
        [HttpPost]
        public ActionResult Edit(InmuebleModel inmueble)
        {
            Result resultado = new Result();
            try
            {
                // TODO: Add insert logic here
                using (var conex = new AdminServicios.DAL.Database1Entities())
                {
                    var rowEdit = conex.CAT_INMUEBLES.Where(x => x.ID_INMUEBLE.Equals(inmueble.Id_Inmueble)).FirstOrDefault();
                    rowEdit.ACTIVO = inmueble.Activo.Equals(1) ? true: false;
                    rowEdit.EMAIL = inmueble.Email;
                    rowEdit.ID_HABITACIONAL = inmueble.Id_Habitacional;
                    rowEdit.NUMEXT = inmueble.NumExt;
                    rowEdit.NUMINT = inmueble.NumInt;
                    rowEdit.PROPIETARIO = inmueble.Propietario;
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
    }
}