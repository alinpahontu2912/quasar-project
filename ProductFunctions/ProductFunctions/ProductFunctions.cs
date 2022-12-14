using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Web.Http;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProductFunctions
{
  public static class ProductFunctions
  {

    static ProductService productService = new();

    [FunctionName("getAllProducts")]
    public static async Task<IActionResult> GetProducts(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products")] HttpRequest req,
        ILogger log)
    {
      int pageNumber = Int32.Parse(req.Query["page"]);
      int pageSize = Int32.Parse(req.Query["pgsize"]);
      List<Product> newProducts = productService.GET(pageNumber-1, pageSize);
      if (newProducts.Count > 0) {
        return new OkObjectResult(JsonConvert.SerializeObject(newProducts, Formatting.Indented));
      } else {
        return new NoContentResult();
      }
    }

    [FunctionName("addProduct")]
    public static async Task<IActionResult> AddProduct(
    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "products/add/")] HttpRequest req,
ILogger log)
    {
      log.LogInformation("C# HTTP trigger function processed a request.");
      string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      int succesfull = productService.POST(requestBody);
      return succesfull == 1 ? new OkObjectResult("[OK] Product added")
        : new BadRequestObjectResult("Not a valid product");
    }

    [FunctionName("DeleteProduct")]
    public static async Task<IActionResult> DeleteProduct(
    [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "products/delete/{id:int?}")] HttpRequest req, int id,
ILogger log)
    {
      log.LogInformation("C# HTTP trigger function processed a request.");
      int succesfullDelete = productService.DELETE(id);
      return succesfullDelete == 1 ? new OkObjectResult("[OK] Product removed")
        : new BadRequestObjectResult("No such product exists");
    }

    [FunctionName("UpdatePrice")]
    public static async Task<IActionResult> UpdatePrice(
    [HttpTrigger(AuthorizationLevel.Function, "put", Route = "products/{id:int?}/{price:int?}")] HttpRequest req, int id, int price,
ILogger log)
    {
      log.LogInformation("C# HTTP trigger function processed a request.");
      int successfull = productService.POST(id, price);
      return successfull == 1 ? new OkObjectResult("[OK] Price updated")
        : new BadRequestErrorMessageResult("Price is not accepted");



    }

  }
}
