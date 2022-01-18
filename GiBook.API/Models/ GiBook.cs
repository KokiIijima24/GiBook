using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gibook.API.Models
{
  public class GiBook
  {
    [Key]
    public Guid GiBookId { get; set; }
    public Guid LocationId { get; set; }
    public string GiverId { get; set; }
    public string RecieverId { get; set; }
    public Guid BookId { get; set; }
    public Location Location { get; set; }
    [ForeignKey("GiverId")]
    public AppUser Giver { get; set; }
    [ForeignKey("RecieverId")]
    public AppUser Reciever { get; set; }
    public Book Book { get; set; }
  }
}