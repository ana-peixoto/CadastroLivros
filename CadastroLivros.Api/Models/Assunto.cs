using System.ComponentModel.DataAnnotations;

namespace CadastroLivros.Api.Models
{
    public class Assunto
    {
        [Key]
        [Required]
        public int codAs{ get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
