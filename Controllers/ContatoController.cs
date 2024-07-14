using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto_MVC.Context;
using Projeto_MVC.Models;


namespace Projeto_MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contatos = _context.contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if(ModelState.IsValid)
            {
                _context.contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.contatos.Find(id);

            if(contato == null)
                return RedirectToAction(nameof(Index));
            
            return View(contato); 
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoBanco = _context.contatos.Find(contato.Id);

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.contatos.Update(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.contatos.Find(id);

            if(contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }


        public IActionResult Deletar(int id)
        {
            var contato = _context.contatos.Find(id);

            if(contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoBanco = _context.contatos.Find(contato.Id);
            
            _context.contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}