using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace dotnetapp.Models{

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int SupplierID { get; set; }
    public int CategoryID { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public short UnitsOnOrder { get; set; }
    public short RecorderLevel { get; set; }
    public bool Discontinued { get; set; }

    [ForeignKey("CategoryID")]
    public virtual Category Category { get; set; }
}
}