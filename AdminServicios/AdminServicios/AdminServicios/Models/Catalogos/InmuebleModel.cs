using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminServicios.Models.Catalogos
{
    public class InmuebleModel
    {
        public int Id_Inmueble { get; set; }
        public int Id_Residencial { get; set; }
        public int Id_Habitacional { get; set; }
        public string Residencial { get; set; }
        public string Habitacional { get; set; }
        public string NumExt { get; set; }
        public string NumInt { get; set; }
        public string Propietario { get; set; }
        public string Email { get; set; }
        public int Activo { get; set; }
    }
}