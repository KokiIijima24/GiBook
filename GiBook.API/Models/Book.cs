using System;
using System.ComponentModel.DataAnnotations;

namespace Gibook.API.Models
{
  public class Book
  {
    [Key]
    public Guid BookId { get; set; }
    public string Name { get; set; }
  }
}