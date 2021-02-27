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
        [HttpGet]
        [Route("api/ContenidoReproduccion/getListaCapitulosSerie")]
        public IEnumerable<capituloseriedto> getListaCapitulosSerie(int id_contenido_multimedia)
        {
            return capitulo.getListaCapitulosSerie(id_contenido_multimedia);
        }

        [HttpGet]
        [Route("api/ContenidoReproduccion/getListaSeries")]
        public IEnumerable<contenidomultimediagenerodto> getListaSeries()
        {
            return contenidos_multimedia.getListaSeries();
        }

        [HttpGet]
        [Route("api/ContenidoReproduccion/getListaSubtitulosCapituloSerie")]
        public capituloseriesubdto getListaSubtitulosCapituloSerie(int id_capitulo)

        {
            return capitulo.getListaSubtitulosCapituloSerie(id_capitulo);
        }
    }
}
