using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminServicios.Models.Catalogos
{
    public class ContratoModel
    {
        public ContratoModel()
        {
            Costos = new List<CostosContratoModel>();
        }
        public int Id_Contrato { get; set; }
        public int Id_Residencial { get; set; }
        public int Id_Habitacional { get; set; }
        public string Residencial { get; set; }
        public string Habitacional { get; set; }
        public string Contrato { get; set; }
        public string DocumentoUpload { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<CostosContratoModel> Costos { get; set; }
        public int Activo { get; set; }
    }
}