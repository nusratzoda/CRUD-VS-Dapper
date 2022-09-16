using Domain;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController
{
    private CategoriesServices _categoriesservices;
    public CategoriesController()
    {
        _categoriesservices = new CategoriesServices();
    }
    [HttpGet]
    public List<Categories> GetCategories()
    {
        return _categoriesservices.GetCategories();
    }
    [HttpPost]
    public int AddCategories(Categories categories)
    {
        return _categoriesservices.AddCategories(categories);
    }

    [HttpPut]
    public int UpdateCategories(Categories categories)
    {
        return _categoriesservices.UpdateCategories(categories);
    }
    [HttpDelete]
    public int GetCategories(int id)
    {
        return _categoriesservices.DeleteCategories(id);
    }
}
