using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao
    {
        IEnumerable<Categoria> BuscaCategorias();
        Leilao BuscaLeilaoPorId(int id);
        IEnumerable<Leilao> BuscarLeiloes();
        void Inserir(Leilao leilao);
        void Alterar(Leilao leilao);
        void Remover(Leilao leilao);
    }
}