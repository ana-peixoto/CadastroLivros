using CadastroLivros.Api.Models;

namespace CadastroLivros.Api.DBContext
{
    public interface ILivroRepository
    {
        void SaveChanges();

        IEnumerable<Livro> GetAllLivros();
        Livro GetLivroById(int id);
        void CreateLivro(Livro Livro);
        void UpdateLivro(Livro Livro);
        void DeleteLivro(Livro Livro);
    }
}