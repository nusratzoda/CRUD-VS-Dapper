using Domain;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("[controller]")]
public class AuthorController : Microsoft.AspNetCore.Mvc.ControllerBase
{
    private AuthoServices _authorservices;
    public AuthorController()
    {
        _authorservices = new AuthoServices();
    }
    [HttpGet]
    public List<Author> GetAuthors()
    {
        return _authorservices.GetAuthors();
    }
    [HttpPost]
    public int AddAuthor(Author author)
    {
        return _authorservices.AddAuthor(author);
    }

    [HttpPut]
    public int UpdateAuthor(Author author)
    {
        return _authorservices.UpdateAuthor(author);
    }
    [HttpDelete]
    public int GetAuthors(int id)
    {
        return _authorservices.DeleteAuthor(id);
    }
}
