using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProductFunctions
{
  internal class ProductService
  {
    public DummyDB dummyDB = new DummyDB();
    SqlConnection conn = new(@"Server=DEVSQL\SQL2012;Database=training_alin;Trusted_Connection=True;");

    public async Task<bool> DeleteProduct(int productId)
    {

      try
      {
        conn.Open();
        string query = $"delete from Products where id={productId};";
        using (SqlCommand cmd = new(query, conn))
        {
          await cmd.ExecuteNonQueryAsync();
          conn.Close();
          return true;
        }
      }
      catch (Exception ex)
      {
        conn.Close();
        return false;
      }
    }

    public async Task<int> getProductCount() {
      int dbCount = 0;
      try
      {
        conn.Open();
        string query = $"select count(*) from Products;";
        using (SqlCommand cmd = new(query, conn))
        {
          dbCount = (Int32)cmd.ExecuteScalar();
        }
        conn.Close();
        return dbCount;
      }
      catch (Exception ex)
      {
        return -1;
      }
    }

    public async Task<List<Product>> GetNewProducts(int pageNumber, int pageSize)
    {

      int startIndex = -1, endIndex = -1;
      string query = "";
      List<Product> newProducts = new();
      int dbCount = await getProductCount();      
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
        conn.Open();
        query = $"select * from Products where id >= {startIndex} and id < {endIndex};";
        Console.WriteLine(query);
        using (SqlCommand cmd = new(query, conn))
        {
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              int id = reader.GetInt32(reader.GetOrdinal("id"));
              string name = reader.GetString(reader.GetOrdinal("name"));
              int price = reader.GetInt32(reader.GetOrdinal("price"));
              string description = reader.GetString(reader.GetOrdinal("description"));
              string image = reader.GetString(reader.GetOrdinal("image"));
              newProducts.Add(new Product(id, name, price, image, description));
            }
          }
          conn.Close();
          return newProducts;
        }
      }
      catch (Exception ex)
      {
        return newProducts;
      }
    }

    public List<Product> GetAllProducts()
    {
      List<Product> allProducts = new();
      conn.Open();
      using (SqlCommand cmd = new("select * from Products;", conn))
      {
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            int id = reader.GetInt32(reader.GetOrdinal("id"));
            string name = reader.GetString(reader.GetOrdinal("name"));
            int price = reader.GetInt32(reader.GetOrdinal("price"));
            string description = reader.GetString(reader.GetOrdinal("description"));
            string image = reader.GetString(reader.GetOrdinal("image"));
            allProducts.Add(new Product(id, name, price, image, description));
          }
        }
        conn.Close();
        return allProducts;
      }
    }

    public async Task<bool> AddNewProduct(string data)
    {
      try
      {
        conn.Open();
        Product newProduct = JsonConvert.DeserializeObject<Product>(data);
        string query = $"insert into Products values({newProduct.id}, '{newProduct.name}', {newProduct.price}, '{newProduct.description}', '{newProduct.image}');";
        using (SqlCommand cmd = new(query, conn))
        {
          await cmd.ExecuteNonQueryAsync();
          conn.Close();
          return true;
        }
      }
      catch (Exception ex)
      {
        conn.Close();
        return false;
      }

    }

    public async Task<bool> UpdatePrice(int id, int newPrice)
    {
      try
      {
        conn.Open();
        string query = $"update Products set price = {newPrice} where id = {id};";
        using (SqlCommand cmd = new(query, conn))
        {
          await cmd.ExecuteNonQueryAsync();
          conn.Close();
          return true;
        }
      }
      catch (Exception ex)
      {
        conn.Close();
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
