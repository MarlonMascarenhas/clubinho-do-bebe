﻿using AutoMapper;
using ClubinhoDoBebe.Domain;
using ClubinhoDoBebe.Domain.Models;
using ClubinhoDoBebe.Infra.FirebaseConnection;
using ClubinhoDoBebe.Infra.Repository.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClubinhoDoBebe.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IMapper _mapper;
        FirebaseDB firebaseDB = new FirebaseDB(Constantes.UrlFirebase);

        public ProdutoRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Produto> ObterListaProdutos()
        {
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Produto");
            FirebaseResponse getResponse = firebaseDBTeams.Get();

            //var result = JsonConvert.DeserializeObject<Produto>(getResponse.JSONContent);

            return _mapper.Map<List<Produto>>(getResponse.JSONContent);
        }
    }
}
