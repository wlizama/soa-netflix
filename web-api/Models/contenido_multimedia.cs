using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api.Transfers;

namespace web_api.Models
{
    public partial class contenidos_multimedia
    {
        //lista capitulos de serie
        public static IEnumerable<contenidomultimediagenerodto> getListaSeries()
        {
            //http://localhost:64996/api/ContenidoReproduccion/getListaSeries

            netflixdbEntities bd = new netflixdbEntities();

            var list = (
                from conm in bd.contenidos_multimedia
                where conm.id_tcontenido_multimedia == 2 // series
                select new contenidomultimediagenerodto()
                {
                    id_contenido_multimedia = conm.id_contenido_multimedia,
                    titulo = conm.video.titulo,
                    descripcion = conm.video.descripcion,
                    edad_clasificacion = conm.edad_clasificacion,
                    anho_publicacion = conm.anho_publicacion,
                    director = conm.director,
                    url_trailer = conm.video.url_trailer,
                    generos = (from conmgen in bd.contenido_multimedia_generos
                               join gen in bd.generos
                               on conmgen.id_genero equals gen.id_genero
                               where conmgen.id_contenido_multimedia == conm.id_contenido_multimedia
                               select new generodto()
                               {
                                   nombre = gen.nombre
                               }).ToList()
                }
            );

            return list;
        }

    }
}