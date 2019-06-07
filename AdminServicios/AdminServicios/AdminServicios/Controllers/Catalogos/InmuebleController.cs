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
                var inmueble = conex.CAT_INMUEBLE.Where(x => x.ID_INMUEBLE.Equals(id_Inmueble)).FirstOrDefault(); ;
                return PartialView("~/Views/Residencial/Residencial.cshtml", inmueble);
            }

        }
        // GET: Residencial/Create
        public ActionResult Create()
        {
            ViewBag.Editar = 0;
            DAL.CAT_INMUEBLE inmueble = new DAL.CAT_INMUEBLE();
            return PartialView("~/Views/Residencial/Residencial.cshtml", inmueble);
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
        public ActionResult ObtenerInmueble(int id_Habitacional)
        {

        }
    }
}