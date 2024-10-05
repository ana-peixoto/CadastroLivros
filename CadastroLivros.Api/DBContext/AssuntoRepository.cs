using CadastroLivros.Api.DBContext;
using CadastroLivros.Api.Models;

namespace CadastroAssuntos.Api.DBContext
{
    public class AssuntoRepository : IAssuntoRepository
    {
        private readonly AppDbContext _context;

        public AssuntoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAssunto(Assunto Assunto)
        {
            if (Assunto == null)
            {
                throw new ArgumentNullException(nameof(Assunto));
            }

            _context.Assuntos.Add(Assunto);
        }
        public void UpdateAssunto(Assunto Assunto)
        {
            if (Assunto == null)
            {
                throw new ArgumentNullException(nameof(Assunto));
            }

            _context.Assuntos.Update(Assunto);
        }

        public void DeleteAssunto(Assunto Assunto)
        {
            if (Assunto == null)
            {
                throw new ArgumentNullException(nameof(Assunto));
            }

            _context.Assuntos.Remove(Assunto);
        }

        public IEnumerable<Assunto> GetAllAssuntos()
        {
            return _context.Assuntos.ToList();
        }

        public Assunto GetAssuntoById(int id) => _context.Assuntos.FirstOrDefault(c => c.codAs == id);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
