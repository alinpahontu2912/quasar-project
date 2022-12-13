using Newtonsoft.Json;

namespace ProductFunctions
{
    internal class Product
    {
        [JsonRequired]
        public int id;
        [JsonRequired]
        public string name;
        [JsonRequired]
        public int price;
        [JsonRequired]
        public string image;
        [JsonRequired]
        public string description;

        public Product(int id, string name, int price, string image, string description)
        {

            this.id = id;
            this.name = name;
            this.price = price;
            this.image = image;
            this.description = description;
        }
    }
}
