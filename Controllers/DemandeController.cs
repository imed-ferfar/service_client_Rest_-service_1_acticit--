using ServeurActivite_Rest.Models;
using ServeurActivite_Rest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServeurActivite_Rest.Controllers
{
    public class DemandeController : ApiController
    {
        // GET: api/Demande
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Demande/5
       /* public Demande Get(int year)
        {
            return TraitementDemande.GenererDemande(year);
        }*/

        // POST: api/Demande
        public Demande Post([FromBody]Demande demande)
        {
            return TraitementDemande.GenererDemande(demande);
        }

        // PUT: api/Demande/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Demande/5
        public void Delete(int id)
        {
        }
    }
}
