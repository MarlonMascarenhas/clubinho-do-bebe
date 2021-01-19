using AutoMapper;
using ClubinhoDoBebe.Domain;
using ClubinhoDoBebe.Domain.Models;
using ClubinhoDoBebe.Infra.FirebaseConnection;
using ClubinhoDoBebe.Infra.Repository.Interfaces;
using System.Collections.Generic;

namespace ClubinhoDoBebe.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IMapper _mapper;
        FirebaseDB firebaseDB = new FirebaseDB(Constantes.UrlFirebase);


        public List<Produto> ObterListaProdutos()
        {
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Produto");
            FirebaseResponse getResponse = firebaseDBTeams.Get();

            return _mapper.Map<List<Produto>>(getResponse.JSONContent);
        }
    }
}
