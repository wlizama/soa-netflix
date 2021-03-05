using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api.Transfers;

namespace web_api.Models
{
    public partial class contenidos_multimedia
    {

        public static int insertSerie(contenidomultimediaseriedto cms)
        {
            netflixdbEntities bd = new netflixdbEntities();
            video objVideo = new video()
            {
                titulo = cms.titulo,
                descripcion = cms.descripcion,
                url_ubicacion = cms.url_ubicacion,
                url_imagen = cms.url_imagen,
                url_trailer = cms.url_trailer,
                duracion_segundos = cms.duracion_segundos
            };
            bd.videos.Add(objVideo);
            bd.SaveChanges();

            contenidos_multimedia cm = new contenidos_multimedia()
            {
                edad_clasificacion = cms.edad_clasificacion,
                anho_publicacion = cms.anho_publicacion,
                director = cms.director,
                video = objVideo,
                id_tcontenido_multimedia = 2
            };

            bd.contenidos_multimedia.Add(cm);
            bd.SaveChanges();

            var id_contenido_multimedia = cm.id_contenido_multimedia;

            return id_contenido_multimedia;

        }

        public static contenidomultimediaseriedto getSerie(int id_contenido_multimedia)
        {

            netflixdbEntities bd = new netflixdbEntities();

            var result = (
                from conm in bd.contenidos_multimedia
                where conm.id_tcontenido_multimedia == 2 // series
                && conm.id_contenido_multimedia == id_contenido_multimedia
                select new contenidomultimediaseriedto()
                {
                    id_contenido_multimedia = conm.id_contenido_multimedia,
                    edad_clasificacion = conm.edad_clasificacion,
                    anho_publicacion = conm.anho_publicacion,
                    director = conm.director,
                    id_tcontenido_multimedia = conm.id_tcontenido_multimedia,
                    id_video = conm.video.id_video,
                    titulo = conm.video.titulo,
                    descripcion = conm.video.descripcion,
                    url_ubicacion = conm.video.url_ubicacion,
                    url_imagen = conm.video.url_imagen,
                    url_trailer = conm.video.url_trailer,
                    duracion_segundos = conm.video.duracion_segundos
                }
            ).FirstOrDefault();

            return result;
        }


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
                    url_imagen = conm.video.url_imagen,
                    duracion_segundos = conm.video.duracion_segundos,
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