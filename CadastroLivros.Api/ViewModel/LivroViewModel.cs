using CadastroLivros.Api.Models;

namespace CadastroLivros.Api.ViewModel;

public class LivroViewModel
{
    public Livro Livro { get; set; }
    public IEnumerable<Assunto> Assuntos { get; set; }

    public IEnumerable<Autor> Autores { get; set; }
}

