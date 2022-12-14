using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductFunctions
{
  internal class DummyDB
  {
    public List<Product> onDisplayProducts { get; set; }
    private string jsonProducts = @"[
    {
        ""id"": 0,
        ""name"": ""Pod"",
        ""price"": 15,
        ""image"": ""https://cdn.quasar.dev/img/parallax2.jpg"",
        ""description"": ""Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi posuere dictum purus et bibendum. Aenean venenatis tempus auctor. Sed et augue augue. Integer imperdiet venenatis bibendum. Nulla pretium rutrum elit quis consequat. Curabitur a odio eleifend, placerat ligula ut, ornare mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit.""
    },
    {
        ""id"": 1,
        ""name"": ""Apa"",
        ""price"": 20,
        ""image"": ""https://cdn.quasar.dev/img/parallax1.jpg"",
        ""description"": ""Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi posuere dictum purus et bibendum. Aenean venenatis tempus auctor. Sed et augue augue. Integer imperdiet venenatis bibendum. Nulla pretium rutrum elit quis consequat. Curabitur a odio eleifend, placerat ligula ut, ornare mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit.""
    },
    {
        ""id"": 2,
        ""name"": ""Natura"",
        ""price"": 22,
        ""image"": ""https://placeimg.com/500/300/nature"",
        ""description"": ""Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi posuere dictum purus et bibendum. Aenean venenatis tempus auctor. Sed et augue augue. Integer imperdiet venenatis bibendum. Nulla pretium rutrum elit quis consequat. Curabitur a odio eleifend, placerat ligula ut, ornare mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit.""
    }
]
";
    private JsonSerializerOptions options = new JsonSerializerOptions { IncludeFields = true, NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals };
    public DummyDB()
    {
      onDisplayProducts = new();
      List<Product> initialList = JsonSerializer.Deserialize<List<Product>>(jsonProducts, options);
      for (int i = 0; i < 18; i++)
      {
        onDisplayProducts.AddRange(initialList);
        onDisplayProducts.AddRange(initialList);
      }
    }
  }
}
