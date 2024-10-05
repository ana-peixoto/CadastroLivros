using CadastroLivros.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Api.DBContext
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateLivro(Livro Livro)
        {
            if (Livro == null)
            {
                throw new ArgumentNullException(nameof(Livro));
            }

            _context.Livros.Add(Livro);
        }
        public void UpdateLivro(Livro Livro)
        {
            if (Livro == null)
            {
                throw new ArgumentNullException(nameof(Livro));
            }

            _context.Livros.Update(Livro);
        }

        public void DeleteLivro(Livro Livro)
        {
            if (Livro == null)
            {
                throw new ArgumentNullException(nameof(Livro));
            }

            _context.Livros.Remove(Livro);
        }

        public IEnumerable<Livro> GetAllLivros()
        {
            return _context.Livros.ToList();
        }

        public Livro GetLivroById(int id) => _context.Livros
            .Include(l => l.Autores)
            .Include(l => l.Assuntos)
            .FirstOrDefault(c => c.Codl == id);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
