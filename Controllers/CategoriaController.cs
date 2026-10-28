using Microsoft.AspNetCore.Mvc;
using TechStoreMVC.Models;

namespace TechStoreMVC.Controllers
{
    public class CategoriasController : Controller // o ":" significa herança
    // Herança = herda as caracteristicas de um Controller. :)
    // Conceito de POO -> Programação Orientada a Objetos
    {
        private readonly CategoriasDB _categoriasDB;
        public CategoriasController()
        {
            _categoriasDB = new CategoriasDB();
        }
        // Passo 02 - Criar a ação
        // Uma view Depende de uma ação e vice-versa
        [HttpGet] // Verbo Http -> para ter os produtos
        public ActionResult Index()
        {
            List<Categorias> categorias = _categoriasDB.Listar();
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Categorias? categorias = _categoriasDB.buscarPorId(id);
            if (categorias is null)
                return NotFound();

                return View(categorias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorias categorias)
        {
            if(!ModelState.IsValid)
                return View(categorias);

            _categoriasDB.Adicionar(categorias);
            TempData["Sucesso"] = 
                "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categorias? categorias = _categoriasDB.buscarPorId(id);
             if (categorias is null)
                return NotFound();
            return View(categorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorias categorias, int id)
        {
            if (id != categorias.Id)
                return BadRequest();

            if(!ModelState.IsValid)
                return View(categorias);

            bool atualizou = _categoriasDB.Atualizar(categorias);    
            if(!atualizou)
                return NotFound();
                    
            TempData["Sucesso"] = 
                "Produto atualizado com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Categorias? categorias = _categoriasDB.buscarPorId(id);
             if (categorias is null)
                return NotFound();
            return View(categorias);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool excluiu = _categoriasDB.Excluir(id);   
            if(!excluiu)
                return NotFound();
                    
            TempData["Sucesso"] = 
                "Produto excluído com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
