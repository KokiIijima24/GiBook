using System;
using System.ComponentModel.DataAnnotations;

namespace Gibook.API.Models
{
  public class Location
  {
    [Key]
    public Guid LocationId { get; set; }

    public string Name { get; set; }
  }
}