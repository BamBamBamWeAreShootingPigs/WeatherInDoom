namespace WetherInDoom.Controllers.Contracts.Buyer
{
    public class CreateBuyerRequest
    {
        public int BuyerId { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public int Passport { get; set; }

        public string HomeAddress { get; set; } = null!;

        public int PhoneNumber { get; set; }

        public bool IsDeleted { get; set; }
    }
}
