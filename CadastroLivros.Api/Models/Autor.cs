using System.ComponentModel.DataAnnotations;

namespace CadastroLivros.Api.Models
{
    public class Autor
    {
        [Key]
        [Required]
        public int CodAu { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }

}
