//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class propietario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public propietario()
        {
            this.cuentas = new HashSet<cuenta>();
        }
    
        public int id_propietario { get; set; }
        public string nombres { get; set; }
        public string nro_telefono { get; set; }
        public string email { get; set; }
        public string contrasenha { get; set; }
        public int id_pais { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cuenta> cuentas { get; set; }
        public virtual pais pais { get; set; }
    }
}
