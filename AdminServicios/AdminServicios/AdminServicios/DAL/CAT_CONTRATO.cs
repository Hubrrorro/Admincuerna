//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminServicios.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAT_CONTRATO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_CONTRATO()
        {
            this.CAT_COSTOS = new HashSet<CAT_COSTOS>();
        }
    
        public int ID_CONTRATO { get; set; }
        public int ID_HABITACIONAL { get; set; }
        public string CONTRATO { get; set; }
        public string DOCUMENTOUPLOAD { get; set; }
        public System.DateTime FECHAINICIO { get; set; }
        public System.DateTime FECHAFIN { get; set; }
        public bool ACTIVO { get; set; }
    
        public virtual CAT_HABITACIONAL CAT_HABITACIONAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAT_COSTOS> CAT_COSTOS { get; set; }
    }
}
