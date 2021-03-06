using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using web_api.Models;
using web_api.Transfers;

namespace web_api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContenidoReproduccionController : ApiController
    {

        // 1 - Lista de series con sus generos
        [HttpGet]
        [Route("api/ContenidoReproduccion/getListaSeries")]
        public IEnumerable<contenidomultimediagenerodto> getListaSeries()
        {
            return contenidos_multimedia.getListaSeries();
        }

        // 2 - Lista capitulos de serie y su temporada
        [HttpGet]
        [Route("api/ContenidoReproduccion/getListaCapitulosSerie")]
        public IEnumerable<capituloseriedto> getListaCapitulosSerie(int id_contenido_multimedia)
        {
            return capitulo.getListaCapitulosSerie(id_contenido_multimedia);
        }

        // 3 - Lista subtitulos de un capitulo de serie
        [HttpGet]
        [Route("api/ContenidoReproduccion/getListaSubtitulosCapituloSerie")]
        public capituloseriesubdto getListaSubtitulosCapituloSerie(int id_capitulo)

        {
            return capitulo.getListaSubtitulosCapituloSerie(id_capitulo);
        }


        
        [HttpGet]
        [Route("api/ContenidoReproduccion/getSerie")]
        public contenidomultimediaseriedto getSerie(int id_contenido_multimedia)
        {
            return contenidos_multimedia.getSerie(id_contenido_multimedia);
        }

        [HttpPut]
        [Route("api/ContenidoReproduccion/insertSerie")]
        public contenidomultimediaseriedto insertSerie(contenidomultimediaseriedto cms)
        {
            return contenidos_multimedia.insertSerie(cms);
        }

        [HttpPost]
        [Route("api/ContenidoReproduccion/modificarSerie")]
        public contenidomultimediaseriedto modificarSerie(int id_contenido_multimedia, contenidomultimediaseriedto cms_new)
        {
            return contenidos_multimedia.modificarSerie(id_contenido_multimedia, cms_new);
        }

        [HttpDelete]
        [Route("api/ContenidoReproduccion/eliminarSerie")]
        public bool eliminarSerie(int id_contenido_multimedia)
        {
            return contenidos_multimedia.eliminarSerie(id_contenido_multimedia);
        }
    }
}
