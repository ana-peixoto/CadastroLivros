using CadastroLivros.Api.Models;

namespace CadastroAssuntos.Api.DBContext
{
    public interface IAssuntoRepository
    {
        void SaveChanges();

        IEnumerable<Assunto> GetAllAssuntos();
        Assunto GetAssuntoById(int id);
        void CreateAssunto(Assunto Assunto);
        void UpdateAssunto(Assunto Assunto);
        void DeleteAssunto(Assunto Assunto);
    }
}