namespace ServerToAngular.Models
{
  public class Donor
  {
    public int Id { get; set; }
    public string Name { get; set; }
   

    public Donor(int id, string name, string description, string image)
    {
      Id = id;
      Name = name;
     // Description = description;
      //Image = image;
    }
  }
}
