using lab3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace lab3.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public CategoriesController(ApplicationContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IResult GetCategories()
        {
            var objCategoryList = _db.Categories.ToList();
            return Results.Json(objCategoryList);
        }

        [HttpPost]
        public IActionResult PostCategories(StringModel stringModel)
        {
            var newCategory = new Category
            {
                
                Name = stringModel.name
            };
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCategories(Category category)
        {
            var objCategoryList = _db.Categories.ToList();
            foreach(var objCategory in objCategoryList)
            {
                if(objCategory.Id == category.Id)
                {
                    _db.Categories.Remove(objCategory);
                    _db.SaveChanges();
                    return Ok();
                }
            }
            
            return NotFound();
        }

       
    }
}
