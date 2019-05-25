using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminServicios.Models
{
    public class Result
    {
        public Result()
        {
            mensajes = new List<string>();
        }

        public Result(bool resultado, string mensaje)
        {
            this.resultado = resultado;
            mensajes = new List<string>();
            mensajes.Add(mensaje);
        }

        public bool resultado { get; set; }
        public List<string> mensajes { get; set; }
        public dynamic datos { get; set; }

        public int codigo { get; set; }
    }
}