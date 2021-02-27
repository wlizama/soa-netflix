using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api.Transfers;

namespace web_api.Models
{
    public partial class capitulo
    {

        //lista capitulos de serie
        public static IEnumerable<capituloseriedto> getListaCapitulosSerie(int id_contenido_multimedia)
        {
            //http://localhost:64996/api/ContenidoReproduccion/getListaCapitulosSerie?id_contenido_multimedia=1

            netflixdbEntities bd = new netflixdbEntities();

            var list = (
                from cap in bd.capitulos
                join temp in bd.temporadas
                on cap.id_temporada equals temp.id_temporada
                join contmult in bd.contenidos_multimedia
                on temp.id_contenido_multimedia equals contmult.id_contenido_multimedia
                where contmult.id_tcontenido_multimedia == 2 && // series
                      contmult.id_contenido_multimedia == id_contenido_multimedia
                select new capituloseriedto()
                {
                    id_capitulo = cap.id_capitulo,
                    nro_capitulo = cap.nro_capitulo,
                    titulo = cap.video.titulo,
                    descripcion = cap.video.descripcion,
                    url_ubicacion = cap.video.url_ubicacion,
                    url_imagen = cap.video.url_imagen,
                    url_trailer = cap.video.url_trailer,
                    duracion_segundos = cap.video.duracion_segundos,
                    temporada = new temporadadto()
                    {
                        id_temporada = temp.id_temporada,
                        nro_temporada = temp.nro_temporada,
                        nombre = temp.nombre
                    }
                }
            );

            return list;
        }

        public static capituloseriesubdto getListaSubtitulosCapituloSerie(int id_capitulo)
        {
            //http://localhost:64996/api/ContenidoReproduccion/getListaSubtitulosCapituloSerie

            netflixdbEntities bd = new netflixdbEntities();

            var list = new capituloseriesubdto()
            {
                subtitulos = (
                from vs in bd.video_subtitulos
                join sub in bd.subtitulos
                on vs.id_subtitulo equals sub.id_subtitulo
                join vi in bd.videos
                on vs.id_video equals vi.id_video
                join cap in bd.capitulos
                on vi.id_video equals cap.id_video
                where cap.id_capitulo == id_capitulo
                select new subtitulodto()
                {
                    id_subtitulo = sub.id_subtitulo,
                    url_ubicacion = sub.url_ubicacion,
                    nombre_idioma = sub.idioma.nombre
                }).ToList()
            };
            return list;
        }
    }
}