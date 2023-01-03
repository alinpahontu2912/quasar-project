/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProductFunctions
{
  internal class DummyDB
  {
    SqlConnection conn = new(@"Server=DEVSQL\SQL2012;Database=training_alin;Trusted_Connection=True;");

    public void test()
    {
      conn.Open();
      using (SqlCommand cmd = new("select * from Product;", conn))
      {
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}",
                reader[0], reader[1], reader[2], reader[3], reader[4]));
          }
        }
      }
    }

    public List<Product> onDisplayProducts { get; set; }
    private string jsonProducts = @"[{
  ""id"": 1,
  ""name"": ""Kelila"",
  ""price"": 42,
  ""image"": ""https://picsum.photos/200/306"",
  ""description"": ""sapien ut nunc vestibulum ante ipsum primis in faucibus orci luctus""
}, {
  ""id"": 2,
  ""name"": ""Hogan"",
  ""price"": 40,
  ""image"": ""https://picsum.photos/200/307"",
  ""description"": ""a suscipit nulla elit ac nulla sed vel enim sit amet nunc viverra dapibus nulla suscipit""
}, {
  ""id"": 3,
  ""name"": ""Jeramey"",
  ""price"": 24,
  ""image"": ""https://picsum.photos/200/308"",
  ""description"": ""in quam fringilla rhoncus mauris enim leo rhoncus sed vestibulum sit amet cursus id turpis integer aliquet massa id lobortis""
}, {
  ""id"": 4,
  ""name"": ""Royce"",
  ""price"": 57,
  ""image"": ""https://picsum.photos/200/309"",
  ""description"": ""ut rhoncus aliquet pulvinar sed nisl nunc rhoncus dui vel sem sed sagittis nam congue""
}, {
  ""id"": 5,
  ""name"": ""Lindsay"",
  ""price"": 96,
  ""image"": ""https://picsum.photos/200/310"",
  ""description"": ""nam nulla integer pede justo lacinia eget tincidunt eget tempus vel""
}, {
  ""id"": 6,
  ""name"": ""Roseanne"",
  ""price"": 29,
  ""image"": ""https://picsum.photos/200/311"",
  ""description"": ""amet consectetuer adipiscing elit proin interdum mauris non ligula pellentesque ultrices phasellus id sapien""
}, {
  ""id"": 7,
  ""name"": ""Angil"",
  ""price"": 58,
  ""image"": ""https://picsum.photos/200/312"",
  ""description"": ""vivamus vel nulla eget eros elementum pellentesque quisque porta volutpat""
}, {
  ""id"": 8,
  ""name"": ""Drucy"",
  ""price"": 38,
  ""image"": ""https://picsum.photos/200/313"",
  ""description"": ""adipiscing lorem vitae mattis nibh ligula nec sem duis aliquam convallis nunc proin""
}, {
  ""id"": 9,
  ""name"": ""Desirae"",
  ""price"": 65,
  ""image"": ""https://picsum.photos/200/314"",
  ""description"": ""rutrum nulla tellus in sagittis dui vel nisl duis ac nibh fusce lacus purus aliquet at feugiat non pretium quis""
}, {
  ""id"": 10,
  ""name"": ""Gussy"",
  ""price"": 75,
  ""image"": ""https://picsum.photos/200/315"",
  ""description"": ""imperdiet et commodo vulputate justo in blandit ultrices enim lorem ipsum dolor sit amet consectetuer adipiscing elit""
}, {
  ""id"": 11,
  ""name"": ""Cazzie"",
  ""price"": 1,
  ""image"": ""https://picsum.photos/200/316"",
  ""description"": ""faucibus orci luctus et ultrices posuere cubilia curae duis faucibus accumsan odio curabitur convallis duis""
}, {
  ""id"": 12,
  ""name"": ""Rikki"",
  ""price"": 92,
  ""image"": ""https://picsum.photos/200/317"",
  ""description"": ""phasellus in felis donec semper sapien a libero nam dui proin leo odio porttitor id consequat in consequat ut nulla""
}, {
  ""id"": 13,
  ""name"": ""Cobby"",
  ""price"": 65,
  ""image"": ""https://picsum.photos/200/318"",
  ""description"": ""a ipsum integer a nibh in quis justo maecenas rhoncus aliquam lacus morbi quis tortor id nulla""
}, {
  ""id"": 14,
  ""name"": ""Skelly"",
  ""price"": 19,
  ""image"": ""https://picsum.photos/200/319"",
  ""description"": ""convallis morbi odio odio elementum eu interdum eu tincidunt in leo maecenas pulvinar lobortis est""
}, {
  ""id"": 15,
  ""name"": ""Jilleen"",
  ""price"": 93,
  ""image"": ""https://picsum.photos/200/320"",
  ""description"": ""odio curabitur convallis duis consequat dui nec nisi volutpat eleifend donec ut dolor morbi vel lectus""
}, {
  ""id"": 16,
  ""name"": ""Andris"",
  ""price"": 55,
  ""image"": ""https://picsum.photos/200/321"",
  ""description"": ""pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin mi sit""
}, {
  ""id"": 17,
  ""name"": ""Phip"",
  ""price"": 68,
  ""image"": ""https://picsum.photos/200/322"",
  ""description"": ""integer a nibh in quis justo maecenas rhoncus aliquam lacus morbi quis tortor id nulla ultrices aliquet maecenas leo""
}, {
  ""id"": 18,
  ""name"": ""Silvia"",
  ""price"": 75,
  ""image"": ""https://picsum.photos/200/323"",
  ""description"": ""tortor sollicitudin mi sit amet lobortis sapien sapien non mi integer ac neque duis bibendum morbi non quam nec dui""
}, {
  ""id"": 19,
  ""name"": ""Lilas"",
  ""price"": 32,
  ""image"": ""https://picsum.photos/200/324"",
  ""description"": ""ac neque duis bibendum morbi non quam nec dui luctus rutrum nulla tellus in sagittis dui vel nisl""
}, {
  ""id"": 20,
  ""name"": ""Jeramie"",
  ""price"": 41,
  ""image"": ""https://picsum.photos/200/325"",
  ""description"": ""nonummy integer non velit donec diam neque vestibulum eget vulputate ut ultrices vel augue vestibulum ante""
}, {
  ""id"": 21,
  ""name"": ""Glenden"",
  ""price"": 44,
  ""image"": ""https://picsum.photos/200/326"",
  ""description"": ""vitae mattis nibh ligula nec sem duis aliquam convallis nunc proin at turpis a pede posuere""
}, {
  ""id"": 22,
  ""name"": ""Booth"",
  ""price"": 63,
  ""image"": ""https://picsum.photos/200/327"",
  ""description"": ""molestie sed justo pellentesque viverra pede ac diam cras pellentesque volutpat dui maecenas tristique""
}, {
  ""id"": 23,
  ""name"": ""Pattie"",
  ""price"": 47,
  ""image"": ""https://picsum.photos/200/328"",
  ""description"": ""ultrices posuere cubilia curae nulla dapibus dolor vel est donec odio justo""
}, {
  ""id"": 24,
  ""name"": ""Alexandro"",
  ""price"": 85,
  ""image"": ""https://picsum.photos/200/329"",
  ""description"": ""ridiculus mus etiam vel augue vestibulum rutrum rutrum neque aenean auctor gravida sem praesent id massa id nisl""
}, {
  ""id"": 25,
  ""name"": ""Welbie"",
  ""price"": 17,
  ""image"": ""https://picsum.photos/200/330"",
  ""description"": ""nunc proin at turpis a pede posuere nonummy integer non velit donec diam neque vestibulum eget""
}, {
  ""id"": 26,
  ""name"": ""Anya"",
  ""price"": 53,
  ""image"": ""https://picsum.photos/200/331"",
  ""description"": ""volutpat dui maecenas tristique est et tempus semper est quam pharetra magna""
}, {
  ""id"": 27,
  ""name"": ""Raoul"",
  ""price"": 84,
  ""image"": ""https://picsum.photos/200/332"",
  ""description"": ""non lectus aliquam sit amet diam in magna bibendum imperdiet""
}, {
  ""id"": 28,
  ""name"": ""Paulina"",
  ""price"": 62,
  ""image"": ""https://picsum.photos/200/333"",
  ""description"": ""eu magna vulputate luctus cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus""
}, {
  ""id"": 29,
  ""name"": ""Peterus"",
  ""price"": 87,
  ""image"": ""https://picsum.photos/200/334"",
  ""description"": ""suspendisse potenti in eleifend quam a odio in hac habitasse platea dictumst maecenas ut massa quis""
}, {
  ""id"": 30,
  ""name"": ""Barnaby"",
  ""price"": 5,
  ""image"": ""https://picsum.photos/200/335"",
  ""description"": ""mus vivamus vestibulum sagittis sapien cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus""
}, {
  ""id"": 31,
  ""name"": ""Arden"",
  ""price"": 51,
  ""image"": ""https://picsum.photos/200/336"",
  ""description"": ""mus etiam vel augue vestibulum rutrum rutrum neque aenean auctor gravida sem praesent""
}, {
  ""id"": 32,
  ""name"": ""Zeke"",
  ""price"": 45,
  ""image"": ""https://picsum.photos/200/337"",
  ""description"": ""sit amet cursus id turpis integer aliquet massa id lobortis convallis tortor risus dapibus augue vel accumsan""
}, {
  ""id"": 33,
  ""name"": ""Natka"",
  ""price"": 94,
  ""image"": ""https://picsum.photos/200/338"",
  ""description"": ""amet eleifend pede libero quis orci nullam molestie nibh in lectus pellentesque""
}, {
  ""id"": 34,
  ""name"": ""Fidole"",
  ""price"": 36,
  ""image"": ""https://picsum.photos/200/339"",
  ""description"": ""quis libero nullam sit amet turpis elementum ligula vehicula consequat morbi a ipsum""
}, {
  ""id"": 35,
  ""name"": ""Clarance"",
  ""price"": 94,
  ""image"": ""https://picsum.photos/200/340"",
  ""description"": ""varius nulla facilisi cras non velit nec nisi vulputate nonummy maecenas tincidunt lacus""
}, {
  ""id"": 36,
  ""name"": ""Kippar"",
  ""price"": 31,
  ""image"": ""https://picsum.photos/200/350"",
  ""description"": ""purus eu magna vulputate luctus cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus""
}, {
  ""id"": 37,
  ""name"": ""Frannie"",
  ""price"": 7,
  ""image"": ""https://picsum.photos/200/360"",
  ""description"": ""in tempus sit amet sem fusce consequat nulla nisl nunc nisl duis bibendum felis sed interdum venenatis""
}, {
  ""id"": 38,
  ""name"": ""Charmain"",
  ""price"": 10,
  ""image"": ""https://picsum.photos/200/370"",
  ""description"": ""leo odio condimentum id luctus nec molestie sed justo pellentesque viverra pede ac diam cras pellentesque""
}, {
  ""id"": 39,
  ""name"": ""Silas"",
  ""price"": 53,
  ""image"": ""https://picsum.photos/200/380"",
  ""description"": ""vitae ipsum aliquam non mauris morbi non lectus aliquam sit amet diam in magna""
}, {
  ""id"": 40,
  ""name"": ""Hephzibah"",
  ""price"": 30,
  ""image"": ""https://picsum.photos/200/390"",
  ""description"": ""sed ante vivamus tortor duis mattis egestas metus aenean fermentum donec ut mauris eget""
}, {
  ""id"": 41,
  ""name"": ""Idalia"",
  ""price"": 91,
  ""image"": ""https://picsum.photos/200/391"",
  ""description"": ""ipsum integer a nibh in quis justo maecenas rhoncus aliquam""
}, {
  ""id"": 42,
  ""name"": ""Sharleen"",
  ""price"": 27,
  ""image"": ""https://picsum.photos/200/392"",
  ""description"": ""quam fringilla rhoncus mauris enim leo rhoncus sed vestibulum sit amet cursus id turpis integer aliquet massa id lobortis convallis""
}, {
  ""id"": 43,
  ""name"": ""Lauryn"",
  ""price"": 64,
  ""image"": ""https://picsum.photos/200/393"",
  ""description"": ""augue vestibulum rutrum rutrum neque aenean auctor gravida sem praesent id massa id nisl venenatis lacinia""
}, {
  ""id"": 44,
  ""name"": ""Curtis"",
  ""price"": 95,
  ""image"": ""https://picsum.photos/200/394"",
  ""description"": ""nullam varius nulla facilisi cras non velit nec nisi vulputate nonummy maecenas tincidunt lacus at velit""
}, {
  ""id"": 45,
  ""name"": ""Lemmy"",
  ""price"": 26,
  ""image"": ""https://picsum.photos/200/395"",
  ""description"": ""quis libero nullam sit amet turpis elementum ligula vehicula consequat morbi a ipsum integer a nibh in quis justo maecenas""
}, {
  ""id"": 46,
  ""name"": ""Dorena"",
  ""price"": 16,
  ""image"": ""https://picsum.photos/200/301"",
  ""description"": ""nonummy maecenas tincidunt lacus at velit vivamus vel nulla eget eros""
}, {
  ""id"": 47,
  ""name"": ""Brucie"",
  ""price"": 46,
  ""image"": ""https://picsum.photos/200/302"",
  ""description"": ""cubilia curae mauris viverra diam vitae quam suspendisse potenti nullam""
}, {
  ""id"": 48,
  ""name"": ""Mel"",
  ""price"": 9,
  ""image"": ""https://picsum.photos/200/303"",
  ""description"": ""ut massa volutpat convallis morbi odio odio elementum eu interdum eu""
}, {
  ""id"": 49,
  ""name"": ""Lief"",
  ""price"": 79,
  ""image"": ""https://picsum.photos/200/304"",
  ""description"": ""orci luctus et ultrices posuere cubilia curae mauris viverra diam vitae quam suspendisse""
}, {
  ""id"": 50,
  ""name"": ""Jarvis"",
  ""price"": 16,
  ""image"": ""https://picsum.photos/200/305"",
  ""description"": ""leo odio porttitor id consequat in consequat ut nulla sed accumsan felis ut at dolor""
}]
";
    private JsonSerializerOptions options = new JsonSerializerOptions { IncludeFields = true, NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals };
    public DummyDB()
    {
      onDisplayProducts = new();
      List<Product> initialList = JsonSerializer.Deserialize<List<Product>>(jsonProducts, options);
      onDisplayProducts.AddRange(initialList);
    }
  }
}
*/
