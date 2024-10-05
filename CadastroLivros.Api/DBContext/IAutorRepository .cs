using CadastroLivros.Api.Models;

namespace CadastroAutors.Api.DBContext
{
    public interface IAutorRepository
    {
        void SaveChanges();

        IEnumerable<Autor> GetAllAutores();
        Autor GetAutorById(int id);
        void CreateAutor(Autor Autor);
        void UpdateAutor(Autor Autor);
        void DeleteAutor(Autor Autor);
    }
}