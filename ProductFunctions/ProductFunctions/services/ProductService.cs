using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFunctions {
  internal class ProductService
  {
    public DummyDB dummyDB = new DummyDB();

    SqlConnection conn = new(@"Server=DEVSQL\SQL2012;Database=training_alin;Trusted_Connection=True;");

    public async Task<bool> DeleteProduct(int productId)
    {
      try
      {
        using (var dataBase = new TrainingAlinContext())
        {
          Product productToRemove = dataBase.Products.Where(prod => prod.Id == productId).First();
          dataBase.Products.Remove(productToRemove);
          await dataBase.SaveChangesAsync();
          return true;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }

    }

    public int getProductCount()
    {
      int dbCount = 0;
      try
      {
        using (var dataBase = new TrainingAlinContext())
        {
          dbCount = dataBase.Products.Count();
        }
        return dbCount;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return dbCount;
      }

    }

    public List<Product> GetNewProducts(int pageNumber, int pageSize)
    {

      int startIndex = -1, endIndex = -1;
      string query = "";
      List<Product> newProducts = new();
      int dbCount = getProductCount();
      if (pageNumber * pageSize + pageSize <= dbCount)
      {
        startIndex = pageNumber * pageSize;
        endIndex = startIndex + pageSize;
      }
      else if (pageNumber * pageSize + pageSize >= dbCount && pageNumber * pageSize <= dbCount)
      {
        int remainingPages = dbCount - pageNumber * pageSize;
        startIndex = pageNumber * pageSize;
        endIndex = startIndex + remainingPages;
      }
      try
      {
        using (var dataBase = new TrainingAlinContext())
        {
          newProducts = dataBase.Products.Where(product => product.Id >= startIndex && product.Id < endIndex).ToList();
          return newProducts;
        }
      }
      catch (Exception ex)
      {

        Console.WriteLine(ex.Message);
        return newProducts;
      }
    }

    public List<Product> GetAllProducts()
    {

      List<Product> allProducts = new();
      try
      {
        using (var dataBase = new TrainingAlinContext())
        {
          allProducts = dataBase.Products.Select(prod => prod).ToList();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return allProducts;
    }

    public async Task<bool> AddNewProduct(string data)
    {
      try
      {
        using (var dataBase = new TrainingAlinContext())
        {
          Product newProduct = JsonConvert.DeserializeObject<Product>(data);
          dataBase.Products.Add(newProduct);
          await dataBase.SaveChangesAsync();
          return true;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }

    }

    public async Task<bool> UpdatePrice(int id, int newPrice)
    {
      try
      {
        using (var dataBase = new TrainingAlinContext())
        {
          Product wantedProduct = dataBase.Products.Where(product => product.Id == id).First();
          wantedProduct.Price = newPrice;
          await dataBase.SaveChangesAsync();
          return true;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
    }

    public async Task populateDB()
    {

      foreach (var prod in dummyDB.onDisplayProducts)
      {
        string data = JsonConvert.SerializeObject(prod, Formatting.Indented);
        await AddNewProduct(data);
      }
    }

  }
}
