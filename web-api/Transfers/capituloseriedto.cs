using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api.Models;

namespace web_api.Transfers
{
    public class capituloseriedto
    {
        public int id_capitulo { get; set; }
        public Nullable<int> nro_capitulo { get; set; }

        // datos de video
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string url_ubicacion { get; set; }
        public string url_imagen { get; set; }
        public string url_trailer { get; set; }
        public Nullable<decimal> duracion_segundos { get; set; }

        public virtual temporadadto temporada { get; set; }
    }
}