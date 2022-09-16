using Dapper;
using Domain;
using Npgsql;

namespace Infrastructura.Services;

public class CategoriesServices
{
    private string? _conectionString;


    public CategoriesServices()
    {
        _conectionString = " Server=127.0.0.1;Port=5432;Database=homework;User Id= postgres;Password=882003421sb.;";
    }

    public List<Categories> GetCategories()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            var response = connection.Query<Categories>($"select * from Categories;").ToList();
            return response;
        }
    }

    public int AddCategories(Categories categories)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string? sql = $"Insert into categories (id,Name ) VAlUES ('{categories.id}','{categories.Name}')";
            var response = connection.Execute(sql);
            return response;
        }
    }
    public int DeleteCategories(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"delete from Categories where id = '{id}';";
            var response = connection.Execute(sql);
            return response;
        }
    }
    public int UpdateCategories(Categories categories)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"update categories set Name = '{categories.Name}', id = '{categories.id}' WHERE id = '{categories.id}';";
            var response = connection.Execute(sql);
            return response;
        }
    }
}
