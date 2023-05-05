using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using DataAccess;
using Domain.Models;
using Domain.Interfaces;
using WetherInDoom.Controllers.Contracts.Buyer;
using Azure.Core;
using Mapster;

namespace WetherInDoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : Controller
    {
        EthernetShopContext db = new EthernetShopContext();
        private IUserService _userService;
        public BuyersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult ReturnBuyers()
        {
            return Ok(db.Buyers.Select(p => p).ToList());
        }

        [HttpGet("ActiveBuyers")]
        public IActionResult ReturnActiveBuyers()
        {
            return Ok(db.Buyers.Where(p => p.IsDeleted == false).Select(p => p).ToList());
        }

        [HttpGet("{Buyer_Id}")]
        public async Task<IActionResult> SearchByBuyer_id([Required] int Id)
        {
            var result = await _userService.GetById(Id);
            var response = result.Adapt<Buyer>();
            return Ok(response);
            //return Ok(db.Buyers.Where(p => p.BuyerId == Id).Select(p => p).ToList());
        }

        [HttpGet("{Passport}")]
        public IActionResult SearchByPassport([Required] int Passport)
        {
            return Ok(db.Buyers.Where(p => p.Passport == Passport).Select(p => p).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddBuyer(CreateBuyerRequest request)
        {
            try
            {
                var buyerDto = request.Adapt<Buyer>(); 
                await _userService.Create(buyerDto);
                return Ok();
            }
            catch { return BadRequest("Ошибка при добавлении"); }
        }

        [HttpPut]
        public IActionResult EditBuyer([Required] int Buyer_Id, [Required] string Surname, [Required] string Name, [Required] string Patronymic, [Required] int Passport, [Required] string Address, [Required] int Phone)
        {
            try
            {
                Buyer? NewBuyer = db.Buyers.Where(p => p.BuyerId == Buyer_Id).Select(p => p).FirstOrDefault();
                NewBuyer.Name = Name == "" ? NewBuyer.Name : Name;
                NewBuyer.Surname = Surname == "" ? NewBuyer.Surname : Surname;
                NewBuyer.Patronymic = Patronymic == "" ? NewBuyer.Patronymic : Patronymic;
                NewBuyer.Passport = Passport;
                NewBuyer.HomeAddress = Address == "" ? NewBuyer.HomeAddress : Address;
                NewBuyer.PhoneNumber = Phone;
                db.Buyers.Update(NewBuyer);
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при изменении"); }
        }

        [HttpDelete]
        public IActionResult DeleteBuyer([Required] int Buyer_Id)
        {
            try
            {
                db.Remove(db.Buyers.Single(a => a.BuyerId == Buyer_Id));
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при удалении"); }
        }
    }
}
