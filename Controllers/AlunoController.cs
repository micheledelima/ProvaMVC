using Microsoft.AspNetCore.Mvc;
using ProvaMVC.Data.Repositories.Interfaces;
using ProvaMVC.Models;

namespace ProvaMVC.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var alunos = await _alunoRepository.GetAllAsync();
            return View(alunos);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id);
            if (aluno == null)
                return NotFound();
            
            return View(aluno);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                await _alunoRepository.AddAsync(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id);
            if (aluno == null)
                return NotFound();
            
            return View(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Aluno aluno)
        {
            if (id != aluno.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _alunoRepository.UpdateAsync(aluno);
                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id);
            if (aluno == null)
                return NotFound();
            
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _alunoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
