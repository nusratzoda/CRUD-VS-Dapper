using Dapper;
using Domain;
using Npgsql;

namespace Infrastructura.Services;

public class BookServices
{
    private string? _conectionString;


    public BookServices()
    {
        _conectionString = " Server=127.0.0.1;Port=5432;Database=homework;User Id= postgres;Password=882003421sb.;";
    }

    public List<Books> GetBooks()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            var response = connection.Query<Books>($"select * from Books;").ToList();
            return response;
        }
    }

    public int AddBooks(Books books)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string? sql = $"Insert into books (title,author_id) VAlUES ('{books.title}','{books.author_id}')";
            var response = connection.Execute(sql);
            return response;
        }
    }
    public int DeleteBooks(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"delete from books where id = '{id}';";
            var response = connection.Execute(sql);
            return response;
        }
    }
    public int UpdateBooks(Books books)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"update books set title = '{books.title}', author_id = '{books.author_id}' WHERE Id = '{books.author_id}';";
            var response = connection.Execute(sql);
            return response;
        }
    }
}
