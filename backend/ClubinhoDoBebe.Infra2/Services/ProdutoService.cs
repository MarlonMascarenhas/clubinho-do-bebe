﻿using ClubinhoDoBebe.Domain.Models;
using ClubinhoDoBebe.Infra.Interfaces;
using ClubinhoDoBebe.Infra.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace ClubinhoDoBebe.Infra
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRespository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRespository = produtoRepository;
        }

        public List<Produto> ObterListaProdutos()
        {
            return _produtoRespository.ObterListaProdutos();
        }
    }
}
