using mf_desenvolviment_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_desenvolviment_backend.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context; // Injeção de dependência do contexto do banco de dados
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        // para criar o view de listagem de veiculos: botao direito na action Index -> adicionar exibição e escolher o metodo, o controller e o contexto
        public async Task<IActionResult> Index() // o resultado de uma ação é uma interface IActionResult
        {
            var dados = await _context.Veiculos.ToListAsync(); // vou retornar todos os dados da tabela Veiculos
            return View(dados);
        }
    }
}
