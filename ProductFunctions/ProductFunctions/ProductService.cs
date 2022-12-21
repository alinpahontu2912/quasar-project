using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProductFunctions
{
  internal class ProductService
  {
    public DummyDB dummyDB { get; set; }

    public bool DeleteProduct(int productId)
    {
      var requestedProduct = dummyDB.onDisplayProducts.Find(product => product.id ==  productId);
      if (requestedProduct != null)
      {
        dummyDB.onDisplayProducts.Remove(requestedProduct);
        return true;
      }
      return false;
    }

    public List<Product> GetNewProducts(int pageNumber, int pageSize)
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

    public List<Product> GetAllProducts() {
      return dummyDB.onDisplayProducts;
    }

    public bool AddNewProduct(string data)
    {
      try
      {
        Product newProduct = JsonConvert.DeserializeObject<Product>(data);
        dummyDB.onDisplayProducts.Add(newProduct);
      }
      catch (Exception ex)
      {
        return false;
      }

      return true;
    }

    public bool UpdatePrice(int id, int newPrice)
    {
      var requestedProduct = dummyDB.onDisplayProducts.Find(product => product.id == id);
      if (requestedProduct == null)
      {
        return false;
      }
      else if (newPrice > 0)
      {
        requestedProduct.price = newPrice;
        return true;
      }

      return false;

    }


    public ProductService()
    {
      dummyDB = new();
    }

  }
}
