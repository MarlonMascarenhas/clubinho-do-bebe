using ClubinhoDoBebe.Domain.Models;
using System.Collections.Generic;

namespace ClubinhoDoBebe.Infra.Interfaces
{
    public interface IProdutoService
    {
        List<Produto> ObterListaProdutos();
    }
}
