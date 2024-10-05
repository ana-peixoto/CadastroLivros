using Microsoft.AspNetCore.Mvc;
using CadastroLivros.Api.Models;
using CadastroAutors.Api.DBContext;

public class AutoresController : Controller
{
    private readonly IAutorRepository _autorRepository;

    public AutoresController(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(Autor autor)
    {
        if (ModelState.IsValid)
        {
            _autorRepository.CreateAutor(autor); // Método para adicionar o autor
            _autorRepository.SaveChanges(); // Salva as alterações
            return RedirectToAction("Index"); // Redireciona para a lista de autores
        }
        return View(autor); // Retorna a view com o modelo se a validação falhar
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var autor = _autorRepository.GetAutorById(id);
        if (autor == null)
        {
            return NotFound(); // Retorna 404 se o autor não for encontrado
        }
        return View(autor); // Retorna a view com o autor encontrado
    }


    [HttpPost]
    public IActionResult Edit(Autor autor)
    {
        if (ModelState.IsValid)
        {
            _autorRepository.UpdateAutor(autor); // Atualiza o autor no repositório
            _autorRepository.SaveChanges(); // Salva as alterações
            return RedirectToAction("Index"); // Redireciona para a lista de autores
        }
        return View(autor); // Retorna a view com o modelo se a validação falhar
    }
    [HttpGet]
    public IActionResult Details(int id)
    {
        var autor = _autorRepository.GetAutorById(id);
        if (autor == null)
        {
            return NotFound(); // Retorna 404 se o autor não for encontrado
        }
        return View(autor); // Retorna a view com os detalhes do autor
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var autor = _autorRepository.GetAutorById(id);
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var autor = _autorRepository.GetAutorById(id);
        if (autor != null)
        {
            _autorRepository.DeleteAutor(autor);
            _autorRepository.SaveChanges();
        }
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Index()
    {
        var autores = _autorRepository.GetAllAutores();
        return View(autores);
    }
}
