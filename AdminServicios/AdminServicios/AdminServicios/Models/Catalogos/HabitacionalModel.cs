using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminServicios.Models.Catalogos
{
    public class HabitacionalModel
    {
        public int ID_RESIDENCIAL { get; set; }
        public string RESIDENCIAL { get; set; }
        public int ID_HABITACIONAL { get; set; }
        public string HABITACIONAL { get; set; }
        public bool ACTIVO { get; set; }

    }
}