using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Transfers
{
    public class contenidomultimediagenerodto
    {
        public int id_contenido_multimedia { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> edad_clasificacion { get; set; }
        public Nullable<int> anho_publicacion { get; set; }
        public string url_trailer { get; set; }
        public string director { get; set; }

        public virtual ICollection<generodto> generos { get; set; }
    }
}