using Fiap.Web.Alunos.Data;
using Fiap.Web.Alunos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Controllers
{
    public class ClienteController : Controller
    {
        // acesso ao banco, recebido pelo construtor
        private readonly DatabaseContext _context;

        public ClienteController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // busca todos os clientes, já trazendo o representante de cada um
            var clientes = _context.Clientes.Include(c => c.Representante).ToList();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // lista de representantes vinda do banco pro select da tela
            ViewBag.Representantes = new SelectList(_context.Representantes.ToList(), "RepresentanteId", "NomeRepresentante");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClienteModel clienteModel)
        {
            _context.Clientes.Add(clienteModel);   // marca pra inserir
            _context.SaveChanges();                // grava no Oracle
            TempData["mensagemSucesso"] = $"O cliente {clienteModel.Nome} foi cadastrado com sucesso";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            // busca o cliente pelo id junto com o representante
            var cliente = _context.Clientes
                .Include(c => c.Representante)
                .FirstOrDefault(c => c.ClienteId == id);

            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cliente = _context.Clientes.Find(id);   // busca pelo id
            if (cliente == null)
            {
                return NotFound();
            }

            ViewBag.Representantes = new SelectList(_context.Representantes.ToList(), "RepresentanteId", "NomeRepresentante", cliente.RepresentanteId);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(ClienteModel clienteModel)
        {
            _context.Update(clienteModel);   // marca como modificado
            _context.SaveChanges();
            TempData["mensagemSucesso"] = $"Os dados do cliente {clienteModel.Nome} foram alterados com sucesso";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);   // marca pra apagar
                _context.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do cliente {cliente.Nome} foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemSucesso"] = "OPS !!! Cliente inexistente.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}