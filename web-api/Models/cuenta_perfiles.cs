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
    
    public partial class cuenta_perfiles
    {
        public int id_cuentaperfil { get; set; }
        public Nullable<int> id_cuenta { get; set; }
        public Nullable<int> id_perfil { get; set; }
    
        public virtual cuenta cuenta { get; set; }
        public virtual perfile perfile { get; set; }
    }
}
