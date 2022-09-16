using Dapper;
using Domain;
using Npgsql;

namespace Infrastructura.Services;

public class AuthoServices
{
    private string? _conectionString;


    public AuthoServices()
    {
        _conectionString = " Server=127.0.0.1;Port=5432;Database=homework;User Id= postgres;Password=882003421sb.;";
    }

    public List<Author> GetAuthors()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            var response = connection.Query<Author>($"select * from Author;").ToList();
            return response;
        }
    }

    public int AddAuthor(Author author)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string? sql = $"Insert into author (name,surname,id) VAlUES ('{author.name}','{author.surname}','{author.id}')";
            var response = connection.Execute(sql);
            return response;
        }
    }
    public int DeleteAuthor(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"delete from author where id = {id};";
            var response = connection.Execute(sql);
            return response;
        }
    }
    public int UpdateAuthor(Author author)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"update author set name  = '{author.name}', surname = '{author.surname}', id = '{author.id}' WHERE Id = '{author.id}';";
            var response = connection.Execute(sql);
            return response;
        }
    }

}
