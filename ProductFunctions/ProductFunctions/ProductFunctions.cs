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
    public static class ProductFunctions
    {

        static DummyDB dummyDB = new DummyDB();

        [FunctionName("getAllProducts")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var existingProducts = JsonConvert.SerializeObject(dummyDB.onDisplayProducts, Formatting.Indented);

            return new OkObjectResult(existingProducts);
        }

        [FunctionName("addProduct")]
        public static async Task<IActionResult> AddProduct(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "products/add/")] HttpRequest req,
    ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            try
            {
                dynamic data = JsonConvert.DeserializeObject<Product>(requestBody);
                dummyDB.onDisplayProducts.Add(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Not a proper product");
            }

            return new OkObjectResult("[OK] Product added");
        }

        [FunctionName("DeleteProduct")]
        public static async Task<IActionResult> DeleteProduct(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "products/delete/{id:int?}")] HttpRequest req, int id,
    ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var requestedProduct = dummyDB.onDisplayProducts.Find(product => product.id == id);
            if (requestedProduct != null)
            {
                dummyDB.onDisplayProducts.Remove(requestedProduct);
            }
            else
            {
                return new BadRequestObjectResult("No such product exists");
            }

            return new OkObjectResult("[OK] Product removed");
        }

        [FunctionName("UpdatePrice")]
        public static async Task<IActionResult> UpdatePrice(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "products/{id:int?}/{price:int?}")] HttpRequest req, int id, int price,
    ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var requestedProduct = dummyDB.onDisplayProducts.Find(Product => Product.id == id);
            if (requestedProduct == null)
            {
                return new BadRequestObjectResult("No such product exists");
            }
            else
            {
                if (price > 0)
                {
                    requestedProduct.price = price;
                }
                else return new BadRequestErrorMessageResult("Price is not accepted");

            }
            return new OkObjectResult("[OK] Price updated");
        }

    }
}
