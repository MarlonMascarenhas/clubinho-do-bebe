using ClubinhoDoBebe.Domain.Models;
using System.Collections.Generic;

namespace ClubinhoDoBebe.Infra.Services.Interfaces
{
    public interface IProdutoService
    {
        List<Produto> ObterListaProdutos();
    }
}
