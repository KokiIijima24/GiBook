using System;
using System.ComponentModel.DataAnnotations;

namespace GiBook.API
{
  public class Book
  {
    [Key]
    public Guid BookId { get; set; }
    public string Name { get; set; }
  }
}