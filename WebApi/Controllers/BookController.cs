using Domain;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("[controller]")]
public class BookController
{
    private BookServices _bookservices;
    public BookController()
    {
        _bookservices = new BookServices();
    }
    [HttpGet]
    public List<Books> GetBooks()
    {
        return _bookservices.GetBooks();
    }
    [HttpPost]
    public int AddBooks(Books books)
    {
        return _bookservices.AddBooks(books);
    }

    [HttpPut]
    public int UpdateBooks(Books books)
    {
        return _bookservices.UpdateBooks(books);
    }
    [HttpDelete]
    public int GetBooks(int id)
    {
        return _bookservices.DeleteBooks(id);
    }
}
