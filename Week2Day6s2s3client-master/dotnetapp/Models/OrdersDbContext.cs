using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace dotnetapp.Models{
public class OrdersDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Category> Categories { get; set; }

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
        : base(options)
    {
    }
}
}