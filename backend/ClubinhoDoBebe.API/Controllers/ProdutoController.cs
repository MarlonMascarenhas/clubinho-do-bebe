using Microsoft.AspNetCore.Mvc;
using ClubinhoDoBebe.Infra;
using ClubinhoDoBebe.Infra.FirebaseConnection;
using static System.Console;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubinhoDoBebe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        FirebaseDB firebaseDB = new FirebaseDB("https://clubinhodobebe-cd995-default-rtdb.firebaseio.com/");

        
        //CRUD
        //CREATE, READ, UPDATE, DELETE
        
        // GET: api/<ProdutoController>
        [HttpGet]
        public string Get()
        {
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Produto");
            WriteLine("GET Request");  
            FirebaseResponse getResponse = firebaseDBTeams.Get();  
            WriteLine(getResponse.Success);  
            if(getResponse.Success)  
                WriteLine(getResponse.JSONContent);  
            WriteLine(); 
            return getResponse.JSONContent;
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Produto/" + id);
            WriteLine("GET Request");
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            WriteLine(getResponse.Success);
            if (getResponse.Success)
                WriteLine(getResponse.JSONContent);
            WriteLine();

            return getResponse.JSONContent;
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public void Post([FromBody] string value) 
        {
            

        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
