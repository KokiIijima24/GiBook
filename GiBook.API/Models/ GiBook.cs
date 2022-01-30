using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GiBook.API.Models;

namespace GiBook.API
{
  public class GiBook
  {
    [Key]
    public Guid GiBookId { get; set; }
    public Guid? LocationId { get; set; }
    [ForeignKey("Giver")]
    public string? GiverId { get; set; }
    [ForeignKey("Reciever")]
    public string? RecieverId { get; set; }
    public Guid? BookId { get; set; }
    public Location? Location { get; set; }
    public AppUser? Giver { get; set; }
    public AppUser? Reciever { get; set; }
    public Book? Book { get; set; }
  }
}