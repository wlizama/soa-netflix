using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web_api.Transfers;

namespace web_api.Models
{
    public partial class contenidos_multimedia
    {

        public static contenidomultimediaseriedto insertSerie(contenidomultimediaseriedto cms)
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

            return new contenidomultimediaseriedto()
            {
                id_contenido_multimedia = cm.id_contenido_multimedia,
                titulo = objVideo.titulo,
                descripcion = objVideo.descripcion,
                url_ubicacion = objVideo.url_ubicacion,
                url_imagen = objVideo.url_imagen,
                url_trailer = objVideo.url_trailer,
                duracion_segundos = objVideo.duracion_segundos,
                edad_clasificacion = cm.edad_clasificacion,
                anho_publicacion = cm.anho_publicacion,
                director = cm.director,
                id_video = objVideo.id_video,
                id_tcontenido_multimedia = 2
            };
        }

        public static contenidomultimediaseriedto modificarSerie(int id_contenido_multimedia, contenidomultimediaseriedto cms_new)
        {
            netflixdbEntities bd = new netflixdbEntities();
            contenidos_multimedia cm = bd.contenidos_multimedia.Find(id_contenido_multimedia);

            cm.video.titulo = cms_new.titulo;
            cm.video.descripcion = cms_new.descripcion;
            cm.video.url_ubicacion = cms_new.url_ubicacion;
            cm.video.url_imagen = cms_new.url_imagen;
            cm.video.url_trailer = cms_new.url_trailer;
            cm.video.duracion_segundos = cms_new.duracion_segundos;
            cm.edad_clasificacion = cms_new.edad_clasificacion;
            cm.anho_publicacion = cms_new.anho_publicacion;
            cm.director = cms_new.director;

            bd.Entry(cm).State = EntityState.Modified;
            bd.SaveChanges();

            return cms_new;
        }

        public static bool eliminarSerie(int id_contenido_multimedia)
        {
            netflixdbEntities bd = new netflixdbEntities();
            contenidos_multimedia cm = bd.contenidos_multimedia.Find(id_contenido_multimedia);

            bd.contenidos_multimedia.Remove(cm);
            bd.SaveChanges();

            return true;
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