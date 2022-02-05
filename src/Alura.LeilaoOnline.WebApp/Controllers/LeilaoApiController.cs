using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;
using System.Linq;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        AppDbContext _context;
        LeilaoDAO _dao;

        public LeilaoApiController()
        {
            _context = new AppDbContext();
            _dao = new LeilaoDAO();
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _dao.BuscarLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _dao.BuscaLeilaoPorId(id);
            if (leilao == null)
            {
                return NotFound();
            }
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _dao.Inserir(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            _dao.Alterar(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _dao.BuscaLeilaoPorId(id);
            if (leilao == null)
            {
                return NotFound();
            }

            _dao.Remover(leilao);
            return NoContent();
        }


    }
}
