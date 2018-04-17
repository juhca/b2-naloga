using B2_naloga.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace B2_naloga.Controllers
{
    public class OsebeController : ApiController
    {

        /*
        Oseba[] osebe = new Oseba[]
        {
            new Oseba { id = 1, ime = "Janez", starost = 25},
            new Oseba { id = 2, ime = "Micka", starost = 24},
            new Oseba { id = 3, ime = "Polde", starost = 27}
        };*/
        List<Oseba> osebe = new List<Oseba>
        {
            new Oseba { id = 1, ime = "Janez", starost = 25},
            new Oseba { id = 2, ime = "Micka", starost = 24},
            new Oseba { id = 3, ime = "Polde", starost = 27}
        };

        public string GetAllProducts()
        {
            string json = JsonConvert.SerializeObject(osebe, Formatting.Indented);
            //return osebe;
            return json;
        }
        

        public IHttpActionResult GetProduct(int id)
        {
            var product = osebe.FirstOrDefault((p) => p.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(osebe);
        }
        
        [HttpPost]
        public IHttpActionResult Post(Oseba o)
        {
            //Oseba o = JsonConvert.DeserializeObject<Oseba>(s);
            osebe.Add(new Oseba { id = o.id, ime = o.ime, starost = o.starost });
            //osebe.Add(new Oseba { id = 5, ime = "Tomas", starost = 24 });
            return Ok();
        }
        /*
        [HttpPost]
        public IHttpActionResult Post(String s)
        {
            Oseba o = JsonConvert.DeserializeObject<Oseba>(s);
            osebe.Add(new Oseba { id = o.id, ime = o.ime, starost = o.starost });
            return Ok();
        }*/
    }
}
