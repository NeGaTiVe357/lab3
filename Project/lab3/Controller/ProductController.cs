using lab3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace lab3.Controller
{
    [Route("api/[controller]")]

    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public ProductController(ApplicationContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetProductCategories()
        {
            var productCategories = _db.Product_categories
                .Include(pc => pc.Category)
                .Include(pc => pc.Product)
                .GroupBy(pc => pc.IdProduct)
                .Select(group => new
                {
                    IdProduct = group.Key,
                    ProductName = group.Select(pc => pc.Product.Name).FirstOrDefault(),
                    Description = group.Select(pc => pc.Product.Description).FirstOrDefault(),
                    NameImg = group.Select(pc => pc.Product.NameImg).FirstOrDefault(),
                    Price = group.Select(pc => pc.Product.Price).FirstOrDefault(),
                    Quantity = group.Select(pc => pc.Product.Quantity).FirstOrDefault(),
                    Categories = group.Select(pc => pc.Category.Name).ToList()
                })
                .ToList();

            return Ok(productCategories);
        }


        [HttpPost]
        public async Task<IActionResult> PostProduct(ProdModel product)
        {
            if(product.NameImg == "")
            {
                product.NameImg = null;
                if(product.Description == "")
            {
                product.Description = null;
            }
            
            }
            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                NameImg = product.NameImg,
                Price = product.Price,
                Quantity = product.Quantity
            };

            _db.Products.Add(newProduct);
            _db.SaveChanges(); // Сохраняем изменения, чтобы получить идентификатор продукта

            // Если переданы категории, связываем их с новым продуктом
            if (product.category.Count > 0)
            {
                foreach (int categoryId in product.category)
                {
                    var productCategory = new ProductCategories
                    {
                        IdProduct = newProduct.Id, // Используем полученный идентификатор продукта
                        IdCategories = categoryId
                    };

                    _db.Product_categories.Add(productCategory);
                }

                _db.SaveChanges(); // Сохраняем изменения после добавления связей с категориями
            }
            else
            {
                var productCategory = new ProductCategories
                {
                    IdProduct = newProduct.Id, // Используем полученный идентификатор продукта
                    IdCategories = 0
                };
                _db.Product_categories.Add(productCategory);
                _db.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(IdModel product)
        {
            var productToDelete = _db.Products.FirstOrDefault(p => p.Id == product.Id);

            if (productToDelete != null)
            {
                _db.Products.Remove(productToDelete);

                // Удаляем все связанные категории из таблицы Product_categories
                var categoriesToDelete = _db.Product_categories.Where(pc => pc.IdProduct == product.Id);
                _db.Product_categories.RemoveRange(categoriesToDelete);

                _db.SaveChanges();

                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        public IActionResult Update(ProductMod product)
        {
            if (product.NameImg == "")
            {
                product.NameImg = null;
            }
                if (product.Description == "")
                {
                    product.Description = null;
                }
                var productToEdit = _db.Products.Find(product.Id);
            productToEdit.Name = product.Name ?? productToEdit.Name;
            productToEdit.Description = product.Description ?? productToEdit.Description;
            productToEdit.NameImg = product.NameImg ?? productToEdit.NameImg;
            productToEdit.Price = product.Price ?? productToEdit.Price;
            productToEdit.Quantity = product.Quantity ?? productToEdit.Quantity;

            var categoriesToDelete = _db.Product_categories.Where(pc => pc.IdProduct == product.Id);
            _db.Product_categories.RemoveRange(categoriesToDelete);
            _db.SaveChanges();
            if (product.category.Count > 0)
            {
                foreach (int categoryId in product.category)
                {
                    var productCategory = new ProductCategories
                    {
                        IdProduct = product.Id, // Используем полученный идентификатор продукта
                        IdCategories = categoryId
                    };

                    _db.Product_categories.Add(productCategory);
                }

                _db.SaveChanges(); // Сохраняем изменения после добавления связей с категориями
            }
            else
            {
                var productCategory = new ProductCategories
                {
                    IdProduct = product.Id, // Используем полученный идентификатор продукта
                    IdCategories = 0
                };
                _db.Product_categories.Add(productCategory);
                _db.SaveChanges();
            }
            return Ok();
        }

    }
}
