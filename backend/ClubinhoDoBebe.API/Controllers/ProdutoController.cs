using Microsoft.AspNetCore.Mvc;
using ClubinhoDoBebe.Infra;
using ClubinhoDoBebe.Infra.FirebaseConnection;
using static System.Console;
using System;
using ClubinhoDoBebe.Infra.Services.Interfaces;
using ClubinhoDoBebe.Domain.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubinhoDoBebe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        FirebaseDB firebaseDB = new FirebaseDB("https://clubinhodobebe-cd995-default-rtdb.firebaseio.com/");

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        
        //CRUD
        //CREATE, READ, UPDATE, DELETE
        
        // GET: api/<ProdutoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var produto = _produtoService.ObterListaProdutos();
                return Ok(new BaseReturn<List<Produto>>()
                {
                    Sucesso = true,
                    Mensagem = "Lista de Produtos retornada com sucesso",
                    Resultado = _produtoService.ObterListaProdutos()
                }); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            
            FirebaseDB firebaseDBProd = firebaseDB.Node("Produto/" + id);
            FirebaseResponse getResponse = firebaseDBProd.Get();
            if (getResponse.Success)
                return getResponse.JSONContent;
            Console.WriteLine(getResponse.JSONContent);
            return null;
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public int Post([FromBody] string value) 
        {
            Console.WriteLine(value);
            FirebaseDB firebaseDBProd = firebaseDB.Node("Produto");
            FirebaseResponse postResponse = firebaseDBProd.Post(value);
            if (postResponse.Success) return 200;

            return 400;
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public int Put(string id, [FromBody] string value)
        {
            FirebaseDB firebaseDBProd = firebaseDB.Node("Produto/" + id);
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
