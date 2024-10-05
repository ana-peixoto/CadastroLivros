using CadastroAssuntos.Api.DBContext;
using CadastroLivros.Api.Models;
using Microsoft.AspNetCore.Mvc;

public class AssuntosController : Controller
{
    private readonly IAssuntoRepository _assuntoRepository;

    public AssuntosController(IAssuntoRepository assuntoRepository)
    {
        _assuntoRepository = assuntoRepository;
    }


    public IActionResult Index()
    {
        var assuntos = _assuntoRepository.GetAllAssuntos();
        return View(assuntos);
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Assunto assunto)
    {
        if (ModelState.IsValid)
        {
            _assuntoRepository.CreateAssunto(assunto);
            _assuntoRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(assunto);
    }


    public IActionResult Edit(int id)
    {
        var assunto = _assuntoRepository.GetAssuntoById(id);
        if (assunto == null)
        {
            return NotFound();
        }
        return View(assunto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Assunto assunto)
    {
        if (id != assunto.codAs)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _assuntoRepository.UpdateAssunto(assunto);
            _assuntoRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(assunto);
    }


    public IActionResult Delete(int id)
    {
        var assunto = _assuntoRepository.GetAssuntoById(id);
        if (assunto == null)
        {
            return NotFound();
        }
        return View(assunto);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var assunto = _assuntoRepository.GetAssuntoById(id);
        if (assunto == null)
        {
            return NotFound();
        }

        _assuntoRepository.DeleteAssunto(assunto);
        _assuntoRepository.SaveChanges();
        return RedirectToAction(nameof(Index));
    }



    public IActionResult Details(int id)
    {
        var assunto = _assuntoRepository.GetAssuntoById(id);
        if (assunto == null)
        {
            return NotFound();
        }
        return View(assunto);
    }
}
