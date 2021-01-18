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
            FirebaseDB firebaseDBProd = firebaseDB.Node("Produto/" + id);
            WriteLine("GET Request");
            FirebaseResponse getResponse = firebaseDBProd.Get();
            WriteLine(getResponse.Success);
            if (getResponse.Success)
                WriteLine(getResponse.JSONContent);
            WriteLine();

            return getResponse.JSONContent;
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public int Post([FromBody] string value) 
        {
            FirebaseDB firebaseDBProd = firebaseDB.Node("Produto");
            WriteLine("POST Request");
            FirebaseResponse postResponse = firebaseDBProd.Post(value);
            WriteLine(postResponse.Success);
            if (postResponse.Success) return 200;

            return 400;
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] string value)
        {
            FirebaseDB firebaseDBProd = firebaseDB.Node("Produto");
            WriteLine("PUT Request");
            FirebaseResponse putResponse = firebaseDBProd.Put(value);
            WriteLine(putResponse.Success);
            if (putResponse.Success) return 200;

            return 400;
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            FirebaseDB firebaseDBProd = firebaseDB.Node("Produto/" + id);
            WriteLine("DELETE Request");
            FirebaseResponse deleteResponse = firebaseDBProd.Delete();
            WriteLine(deleteResponse.Success);
            if (deleteResponse.Success) return 200;

            return 400;
        }
    }
}
