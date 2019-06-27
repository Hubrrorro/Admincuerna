using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminServicios.Models.Catalogos
{
    public class CostosContratoModel
    {
        public int Id_Costos { get; set; }
        public int Id_Contrato { get; set; }
        public string Concepto { get; set; }
        public double Costo { get; set; }
        public int Activo { get; set; }
    }
}