using CadastroAssuntos.Api.DBContext;
using CadastroAutors.Api.DBContext;
using CadastroLivros.Api.DBContext;
using CadastroLivros.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class LivrosControllerTests
{
    private readonly Mock<ILivroRepository> _livroRepositoryMock;
    private readonly Mock<IAssuntoRepository> _assuntoRepositoryMock;
    private readonly Mock<IAutorRepository> _autorRepositoryMock;
    private readonly LivrosController _controller;

    public LivrosControllerTests()
    {
        _livroRepositoryMock = new Mock<ILivroRepository>();
        _assuntoRepositoryMock = new Mock<IAssuntoRepository>();
        _autorRepositoryMock = new Mock<IAutorRepository>();
        _controller = new LivrosController(_livroRepositoryMock.Object, _assuntoRepositoryMock.Object, _autorRepositoryMock.Object);
    }

    [Fact]
    public void Create_ValidLivro_RedirectsToIndex()
    {
    
        var livro = new Livro { Codl = 1, Titulo = "Test Book" };
        int[] assuntoIds = { 1 };
        int[] autorIds = { 1 };

      
        _assuntoRepositoryMock.Setup(repo => repo.GetAssuntoById(It.IsAny<int>())).Returns(new Assunto { codAs = 1, Descricao = "Test Assunto" });
        _autorRepositoryMock.Setup(repo => repo.GetAutorById(It.IsAny<int>())).Returns(new Autor { CodAu = 1, Nome = "Test Author" });

      
        var result = _controller.Create(livro, assuntoIds, autorIds) as RedirectToActionResult;

  
        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
        _livroRepositoryMock.Verify(repo => repo.CreateLivro(It.IsAny<Livro>()), Times.Once);
        _livroRepositoryMock.Verify(repo => repo.SaveChanges(), Times.Once);
    }

    [Fact]
    public void Create_InvalidModel_ReturnsViewWithModel()
    {
     
        var livro = new Livro();
        _controller.ModelState.AddModelError("Titulo", "Required");

        var result = _controller.Create(livro, new int[0], new int[0]) as ViewResult;

    
        Assert.NotNull(result);
        Assert.Equal(livro, result.Model);
    }
}
