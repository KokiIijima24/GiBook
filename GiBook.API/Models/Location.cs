using System;
using System.ComponentModel.DataAnnotations;

namespace GiBook.API
{
  public class Location
  {
    [Key]
    public Guid LocationId { get; set; }

    public string Name { get; set; }
  }
}