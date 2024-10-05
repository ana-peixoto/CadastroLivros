using System.ComponentModel.DataAnnotations;

namespace CadastroLivros.Api.Models
{
    public class Livro
    {
        [Key]
        [Required]
        public int Codl { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Edicao { get; set; }
        public string AnoPublicacao { get; set; }

        public virtual ICollection<Autor> Autores { get; set; } = new List<Autor>();
        public virtual ICollection<Assunto> Assuntos { get; set; } = new List<Assunto>();
    }

}
