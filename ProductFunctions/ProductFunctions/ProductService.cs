using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProductFunctions
{
  internal class ProductService
  {
    public DummyDB dummyDB { get; set; }

    public int DELETE(int productId)
    {
      var requestedProduct = dummyDB.onDisplayProducts.Find(product => product.id ==  productId);
      if (requestedProduct != null)
      {
        dummyDB.onDisplayProducts.Remove(requestedProduct);
        return 1;
      }
      return 0;
    }

    public List<Product> GET(int pageNumber, int pageSize)
    {
      List<Product> newProducts = new();
      if (pageNumber * pageSize + pageSize <= dummyDB.onDisplayProducts.Count)
      {
        newProducts = dummyDB.onDisplayProducts.GetRange(pageNumber * pageSize, pageSize);
      }
      else if (pageNumber * pageSize + pageSize >= dummyDB.onDisplayProducts.Count &&  pageNumber * pageSize <= dummyDB.onDisplayProducts.Count)
      {
        int remainingPages = dummyDB.onDisplayProducts.Count - pageNumber * pageSize;
        newProducts = dummyDB.onDisplayProducts.GetRange(pageNumber * pageSize, remainingPages);
      }
      return newProducts;
    }

    public int POST(string data)
    {
      try
      {
        Product newProduct = JsonConvert.DeserializeObject<Product>(data);
        dummyDB.onDisplayProducts.Add(newProduct);
      }
      catch (Exception ex)
      {
        return 0;
      }

      return 1;
    }

    public int POST(int id, int newPrice)
    {
      var requestedProduct = dummyDB.onDisplayProducts.Find(product => product.id == id);
      if (requestedProduct == null)
      {
        return 0;
      }
      else if (newPrice > 0)
      {
        requestedProduct.price = newPrice;
        return 1;
      }

      return 0;

    }


    public ProductService()
    {
      dummyDB = new();
    }

  }
}
