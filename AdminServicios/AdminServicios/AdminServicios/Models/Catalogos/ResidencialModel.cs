using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminServicios.Models.Catalogos
{
    public class ResidencialModel
    {
        public int ID_RESIDENCIAL { get; set; }
        public string RESIDENCIAL { get; set; }
        public bool ACTIVO { get; set; }
        public string ABREVIATURA { get; set; }
    }
}