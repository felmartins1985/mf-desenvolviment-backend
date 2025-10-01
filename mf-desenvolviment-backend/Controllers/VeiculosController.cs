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

        public IActionResult Create() // serve para exibir o formulário de criação de um novo veículo
        {
            return View();
        }
        [HttpPost] // indica que esse método responde a requisições HTTP POST
        public async  Task<IActionResult> Create(Veiculo veiculo)
        {
            if(ModelState.IsValid) // verifica se os dados enviados no formulário são válidos
            {
                _context.Veiculos.Add(veiculo); // adiciona o novo veículo ao contexto do banco de dados
                await _context.SaveChangesAsync(); // salva as alterações no banco de dados
                return RedirectToAction("Index"); // redireciona para a ação Index, que exibe a lista de veículos
            }
            return View(veiculo);
        }

        public async  Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var veiculo = await _context.Veiculos.FindAsync(id);
            if(veiculo == null)
            {
                return NotFound();
            }
            return View(veiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if(id != veiculo.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid) // verifica se os dados enviados no formulário são válidos
            {
                _context.Veiculos.Update(veiculo); // atualiza o veículo ao contexto do banco de dados
                await _context.SaveChangesAsync(); // salva as alterações no banco de dados
                return RedirectToAction("Index"); // redireciona para a ação Index, que exibe a lista de veículos
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null) return NotFound();
            var veiculo =  await _context.Veiculos.FindAsync(id);
            return View(veiculo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) return NotFound();
            var veiculo = await _context.Veiculos.FindAsync(id);
            if(veiculo == null) return NotFound();
            return View(veiculo);
        }

        [HttpPost, ActionName("Delete")]  // ActionName é usado para mapear o nome da ação do método para "Delete"
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if(veiculo == null) return NotFound();
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
