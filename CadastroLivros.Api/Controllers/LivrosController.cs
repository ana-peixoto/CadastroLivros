using Microsoft.AspNetCore.Mvc;
using CadastroLivros.Api.DBContext;
using CadastroLivros.Api.Models;
using CadastroAssuntos.Api.DBContext;
using CadastroAutors.Api.DBContext;
using CadastroLivros.Api.ViewModel;
public class LivrosController : Controller
{
    private readonly ILivroRepository _livroRepository;
    private readonly IAssuntoRepository _assuntoRepository;
    private readonly IAutorRepository _autorRepository;

    public LivrosController(ILivroRepository livroRepository, IAssuntoRepository assuntoRepository, IAutorRepository autorRepository)
    {
        _livroRepository = livroRepository;
        _assuntoRepository = assuntoRepository;
        _autorRepository = autorRepository;
    }

    public IActionResult Index()
    {
        var livros = _livroRepository.GetAllLivros();
        return View(livros);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var assuntos = _assuntoRepository.GetAllAssuntos();
        var autores = _autorRepository.GetAllAutores();

        var viewModel = new LivroViewModel()
        {
            Assuntos = assuntos,
            Autores = autores,
            Livro = new Livro()
        };
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var livro = _livroRepository.GetLivroById(id);
        if (livro == null)
        {
            return NotFound();
        }
        return View(livro);
    }



    [HttpPost]
    public IActionResult Create(Livro livro, int[] assuntoIds, int[] autorIds)
    {
        if (ModelState.IsValid)
        {

            foreach (var assuntoId in assuntoIds)
            {
                var assunto = _assuntoRepository.GetAssuntoById(assuntoId);
                if (assunto != null)
                {
                    livro.Assuntos.Add(assunto);
                }
            }


            foreach (var autorId in autorIds)
            {
                var autor = _autorRepository.GetAutorById(autorId);
                if (autor != null)
                {
                    livro.Autores.Add(autor);
                }
            }

            _livroRepository.CreateLivro(livro);
            _livroRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(livro);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var livro = _livroRepository.GetLivroById(id);
        if (livro == null)
        {
            return NotFound();
        }

        var assuntos = _assuntoRepository.GetAllAssuntos();
        var autores = _autorRepository.GetAllAutores();

        var viewModel = new LivroViewModel()
        {
            Livro = livro,
            Assuntos = assuntos,
            Autores = autores,
        };

        return View(viewModel);
    }


    [HttpPost]
    public IActionResult Edit(Livro livro, int[] assuntoIds, int[] autorIds)
    {
        if (ModelState.IsValid)
        {
            var livroExistente = _livroRepository.GetLivroById(livro.Codl);

            if (livroExistente != null)
            {

                livroExistente.Titulo = livro.Titulo;
                livroExistente.Editora = livro.Editora;
                livroExistente.Edicao = livro.Edicao;
                livroExistente.AnoPublicacao = livro.AnoPublicacao;


                livroExistente.Assuntos.Clear();
                livroExistente.Autores.Clear();


                foreach (var assuntoId in assuntoIds)
                {
                    var assunto = _assuntoRepository.GetAssuntoById(assuntoId);
                    if (assunto != null)
                    {
                        livroExistente.Assuntos.Add(assunto);
                    }
                }


                foreach (var autorId in autorIds)
                {
                    var autor = _autorRepository.GetAutorById(autorId);
                    if (autor != null)
                    {
                        livroExistente.Autores.Add(autor);
                    }
                }

                _livroRepository.UpdateLivro(livroExistente);
                _livroRepository.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        return View(livro);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var livro = _livroRepository.GetLivroById(id);
        if (livro == null)
        {
            return NotFound();
        }
        return View(livro);
    }


    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var livro = _livroRepository.GetLivroById(id);
        if (livro != null)
        {
            _livroRepository.DeleteLivro(livro);
            _livroRepository.SaveChanges();
        }
        return RedirectToAction("Index");
    }


}
