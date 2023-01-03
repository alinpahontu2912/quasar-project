using Newtonsoft.Json;

namespace StoreFunctions
{
  public class Product
  {
    [JsonRequired]
    public int Id { get; set; }
    [JsonRequired]
    public string Name { get; set; }
    [JsonRequired]
    public int Price { get; set; }
    [JsonRequired]
    public string Image { get; set; }
    [JsonRequired]
    public string Description { get; set; }

    public Product(int id, string name, int price, string image, string description)
    {

      this.Id = id;
      this.Name = name;
      this.Price = price;
      this.Image = image;
      this.Description = description;
    }
  }
}
