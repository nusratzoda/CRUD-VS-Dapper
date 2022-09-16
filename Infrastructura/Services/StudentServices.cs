using Dapper;
using Domain;
using Npgsql;

namespace Infrastructura.Services;

public class StudentServices
{
    private string? _conectionString;


    public StudentServices()
    {
        _conectionString = " Server=127.0.0.1;Port=5432;Database=homework;User Id= postgres;Password=882003421sb.;";
    }

    public List<Students> GetStudents()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            var response = connection.Query<Students>($"select * from Students;").ToList();
            return response;
        }
    }

    public int AddStudents(Students students)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string? sql = $"Insert into Students (firstname,lastname,fathername,birthdate,id) VAlUES ('{students.firstname}','{students.lastname}','{students.fathername}','{students.id}')";
            var response = connection.Execute(sql);
            return response;
        }
    }
    public int DeleteStudents(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"delete from students where id = {id};";
            var response = connection.Execute(sql);
            return response;
        }
    }
    public int UpdateStudents(Students students)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"update students set firstname  = '{students.firstname}', lastname = '{students.lastname}', fathername = '{students.fathername}',id = '{students.id}' WHERE Id = '{students.id}';";
            var response = connection.Execute(sql);
            return response;
        }
    }
}
