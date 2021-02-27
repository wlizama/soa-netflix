using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Transfers
{
    public class capituloseriesubdto
    {
        public virtual ICollection<subtitulodto> subtitulos { get; set; }
    }
}