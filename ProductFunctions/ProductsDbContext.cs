using Microsoft.EntityFrameworkCore;
using System;

public class ProductsDbContext : DbContext
{
	public DbSet<Product> Products { get; set; }

  public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
  { }


}
