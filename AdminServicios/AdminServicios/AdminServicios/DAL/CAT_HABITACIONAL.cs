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
    
    public partial class CAT_HABITACIONAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_HABITACIONAL()
        {
            this.CAT_INMUEBLES = new HashSet<CAT_INMUEBLES>();
            this.CAT_INMUEBLE = new HashSet<CAT_INMUEBLE>();
            this.CAT_CONTRATO = new HashSet<CAT_CONTRATO>();
        }
    
        public int Id_HABITACIONAL { get; set; }
        public string HABITACIONAL { get; set; }
        public bool ACTIVO { get; set; }
        public int ID_RESIDENCIAL { get; set; }
    
        public virtual CAT_RESIDENCIAL CAT_RESIDENCIAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAT_INMUEBLES> CAT_INMUEBLES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAT_INMUEBLE> CAT_INMUEBLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAT_CONTRATO> CAT_CONTRATO { get; set; }
    }
}
