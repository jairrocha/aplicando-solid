using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class LeilaoDAO
    {

        public AppDbContext _context;

        public LeilaoDAO()
        {
            _context = new AppDbContext();
        }
        public IEnumerable<Categoria> BuscaCategorias()
        {
            return _context.Categorias.ToList();
        }
        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return _context.Leiloes
                .Include(l => l.Categoria)
                .ToList();
        }
        public Leilao BuscaLeilaoPorId(int id)
        {
            return _context.Leiloes.First(l => l.Id == id);
        }
        public void Inserir(Leilao leilao)
        {
            _context.Add(leilao);
            _context.SaveChanges();
        }
        public void Alterar(Leilao leilao)
        {
            _context.Update(leilao);
            _context.SaveChanges();
        }
        public void Remover(Leilao leilao)
        {
            _context.Remove(leilao);
            _context.SaveChanges();
        }

    }
}
