using ClubinhoDoBebe.Domain.Models;
using System.Collections.Generic;

namespace ClubinhoDoBebe.Infra.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> ObterListaProdutos();
    }
}
