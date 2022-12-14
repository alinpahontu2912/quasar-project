using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Web.Http;

namespace ProductFunctions
{
  internal class ProductService
  {

    public DummyDB dummyDB { get; set; }

    public int DELETE(int productId)
    {
      var requestedProduct = dummyDB.onDisplayProducts.Find(product => product.id == id);
      if (requestedProduct != null)
      {
        dummyDB.onDisplayProducts.remove(requestedProduct);
        return 1;
      }
      return 0;
    }

    public string GET() {
      return JsonConvert.SerializeObject(dummyDB.onDisplayProducts, Formatting.Indented);
    }


    public ProductService()
    {
      dummyDB = new();
    }
  }
}
