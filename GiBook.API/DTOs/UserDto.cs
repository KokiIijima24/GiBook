namespace GiBook.API.DTOs
{
  public class UserDto
  {
    /// <summary>
    /// primary key
    /// </summary>
    /// <value></value>
    public string Id { get; set; }
    public string DisplayName { get; set; }
    public string Token { get; set; }
    public string UserName { get; set; }
    public string Iamge { get; set; }
  }
}