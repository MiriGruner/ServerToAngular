namespace ServerToAngular.Models
{
    public class Gift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Donor { get; set; }
        public int Price { get; set; } = 10;
        public string Description { get; set; }
        public string Image { get; set; }
        public Gift(int id, string name, string donor, int price,string description,string image)
        {
            Id = id;
            Name = name;
            Donor = donor;
            Price = price;
            Description = description;
            Image = image;
        }
    }
}
