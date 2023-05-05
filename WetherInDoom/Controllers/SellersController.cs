using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using DataAccess;
using Domain.Models;

namespace WetherInDoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : Controller
    {
        EthernetShopContext db = new EthernetShopContext();

        [HttpGet]
        public IActionResult ReturnSellers()
        {
            return Ok(db.Sellers.Select(p => p).ToList());
        }

        [HttpGet("ActiveSellers")]
        public IActionResult ReturnActiveSellers()
        {
            return Ok(db.Sellers.Where(p => p.IsDeleted == false).Select(p => p).ToList());
        }

        [HttpGet("{Seller_id}")]
        public IActionResult SearchBySeller_id([Required] int Id)
        {
            return Ok(db.Sellers.Where(p => p.SellerId == Id).Select(p => p).ToList());
        }

        [HttpGet("{Job_title}")]
        public IActionResult SearchByJob_title([Required] string Job_title)
        {
            return Ok(db.Sellers.Where(p => p.JobTitle == Job_title).Select(p => p).ToList());
        }

        [HttpPost]
        public IActionResult AddSeller([Required] int Seller_Id, [Required] string Surname, [Required] string Name, [Required] string Patronymic, [Required] string Job_title, [Required] string Address, [Required] int Phone)
        {
            try
            {
                Seller p = new Seller();
                p.SellerId = Seller_Id;
                p.Surname = Surname;
                p.Name = Name;
                p.Patronymic = Patronymic;
                p.JobTitle = Job_title;
                p.HomeAddress = Address;
                p.PhoneNumber = Phone;
                p.IsDeleted = false;

                db.Sellers.Add(p);
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при добавлении"); }
        }

        [HttpPut]
        public IActionResult EditSeller([Required] int Seller_Id, [Required] string Surname, [Required] string Name, [Required] string Patronymic, [Required] string Job_title, [Required] string Address, [Required] int Phone)
        {
            try
            {
                Seller ? NewSeller = db.Sellers.Where(p => p.SellerId == Seller_Id).Select(p => p).FirstOrDefault();
                NewSeller.Name = Name == "" ? NewSeller.Name : Name;
                NewSeller.Surname = Surname == "" ? NewSeller.Surname : Surname;
                NewSeller.Patronymic = Patronymic == "" ? NewSeller.Patronymic : Patronymic;
                NewSeller.JobTitle = Job_title == "" ? NewSeller.JobTitle : Job_title;
                NewSeller.HomeAddress = Address == "" ? NewSeller.HomeAddress : Address;
                NewSeller.PhoneNumber = Phone;
                db.Sellers.Update(NewSeller);
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при изменении"); }
        }

        [HttpDelete]
        public IActionResult DeleteSeller([Required] int Seller_Id)
        {
            try
            {
                db.Remove(db.Sellers.Single(a => a.SellerId == Seller_Id));
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при удалении"); }
        }
    }
}
