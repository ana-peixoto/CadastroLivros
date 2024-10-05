using CadastroLivros.Api.DBContext;
using CadastroLivros.Api.Models;

namespace CadastroAutors.Api.DBContext
{
    public class AutorRepository : IAutorRepository
    {
        private readonly AppDbContext _context;

        public AutorRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAutor(Autor Autor)
        {
            if (Autor == null)
            {
                throw new ArgumentNullException(nameof(Autor));
            }

            _context.Autores.Add(Autor);
        }
        public void UpdateAutor(Autor Autor)
        {
            if (Autor == null)
            {
                throw new ArgumentNullException(nameof(Autor));
            }

            _context.Autores.Update(Autor);
        }

        public void DeleteAutor(Autor Autor)
        {
            if (Autor == null)
            {
                throw new ArgumentNullException(nameof(Autor));
            }

            _context.Autores.Remove(Autor);
        }

        public IEnumerable<Autor> GetAllAutores()
        {
            return _context.Autores.ToList();
        }

        public Autor GetAutorById(int id) => _context.Autores.FirstOrDefault(c => c.CodAu == id);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
