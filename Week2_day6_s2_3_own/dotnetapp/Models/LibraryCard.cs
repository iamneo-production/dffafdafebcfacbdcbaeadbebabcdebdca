using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace dotnetapp.Models
{
public class LibraryCard
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"LC-\d{5}")]
    public string CardNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public string MemberName { get; set; }

    [Required]
    [FutureDate]
    public DateTime ExpiryDate { get; set; }

    public ICollection<Book> Books { get; set; }
}
}