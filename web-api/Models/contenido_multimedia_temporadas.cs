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
    
    public partial class contenido_multimedia_temporadas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public contenido_multimedia_temporadas()
        {
            this.capitulos = new HashSet<capitulo>();
        }
    
        public int id_cm_temporada { get; set; }
        public Nullable<int> nro_temporada { get; set; }
        public Nullable<int> id_contenido_multimedia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<capitulo> capitulos { get; set; }
        public virtual contenidos_multimedia contenidos_multimedia { get; set; }
    }
}
