using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ClubinhoDoBebe.Infra;
using ClubinhoDoBebe.Infra.FirebaseConnection;
using static System.Console;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubinhoDoBebe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        FirebaseDB firebaseDB = new FirebaseDB("https://clubinhodobebe-cd995-default-rtdb.firebaseio.com/");

        // GET: api/<ClienteController>
        [HttpGet]
        public string Get()
        {
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Cliente");
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            if (getResponse.Success)
                return getResponse.JSONContent;

            return null;
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            FirebaseDB firebaseDBProd = firebaseDB.Node("Cliente/" + id);
            FirebaseResponse getResponse = firebaseDBProd.Get();
            if (getResponse.Success)
                return getResponse.JSONContent;

            return null;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public int Post([FromBody] string value)
        {
            FirebaseDB firebaseDBProd = firebaseDB.Node("Cliente");
            FirebaseResponse postResponse = firebaseDBProd.Post(value);
            if (postResponse.Success) return 200;

            return 400;
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public int Put(string id, [FromBody] string value)
        {
            FirebaseDB firebaseDBProd = firebaseDB.Node("Cliente/" + id);
            FirebaseResponse putResponse = firebaseDBProd.Put(value);
            if (putResponse.Success) return 200;

            return 400;
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            FirebaseDB firebaseDBProd = firebaseDB.Node("Cliente/" + id);
            FirebaseResponse deleteResponse = firebaseDBProd.Delete();
            if (deleteResponse.Success) return 200;

            return 400;
        }
    }
}
