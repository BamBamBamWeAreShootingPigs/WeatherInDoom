using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WetherInDoom.Controllers
{
    public class ProductsController : Controller
    {
        MyDbContext db = new MyDbContext();
        [HttpGet("Список продуктов")]
        public IActionResult ReturnPrdoucts()
        {
            return Ok(db.Products.Select(p=>p).ToList());
        }

        [HttpGet("Поиск товара по Product_id")]
        public IActionResult SearchByPrductId([Required] int Id)
        {
            return Ok(db.Products.Where(p=>p.ProductId==Id).Select(p => p).ToList());
        }

        [HttpGet("Поиск товара по CategoryId")]
        public IActionResult SearchByCategory_Id([Required] int Category_Id)
        {
            return Ok(db.Products.Where(p => p.CategoryId == Category_Id).Select(p => p).ToList());
        }

        [HttpGet("Товары в наличии")]
        public IActionResult ProductsInStock()
        {
            return Ok(db.Products.Where(p => p.QuanityInStock >= 1).Select(p => p).ToList());
        }

        [HttpPost("Добавление товара")]
        public IActionResult AddProduct([Required] int Product_Id, [Required] string Name, [Required] string Description, [Required] decimal Price, [Required] int Category_Id, [Required] int Amount)
        {
            try
            {
                Product p = new Product();
                p.ProductId = Product_Id;
                p.Name = Name;
                p.Description = Description;
                p.Price = Price;
                p.CategoryId = Category_Id;
                p.QuanityInStock = Amount;
                p.IsDeleted = false;

                db.Products.Add(p);
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при добавлении"); }
        }

        [HttpPost("Изменение товара")]
        public IActionResult EditProduct([Required] int Product_Id, [Required] string Name, [Required] string Description, [Required] decimal Price, [Required] int Category_Id, [Required] int Amount)
        {
            try
            {
                Product? NewProduct = db.Products.Where(p => p.ProductId == Product_Id).Select(p => p).FirstOrDefault();
                NewProduct.Name = Name == "" ? NewProduct.Name : Name;
                NewProduct.Description = Description == "" ? NewProduct.Description : Description;
                NewProduct.CategoryId = Category_Id; 
                NewProduct.Price = Price == 0 ? NewProduct.Price : Price;
                NewProduct.QuanityInStock += Amount;
                db.Products.Update(NewProduct);
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при изменении"); }
        }

        [HttpDelete("Удаление товара")]
        public IActionResult DeleteProduct([Required] int Product_Id)
        {
            try
            {
                db.Remove(db.Products.Single(a => a.ProductId == Product_Id));
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при удалении"); }
        }
    }
}
