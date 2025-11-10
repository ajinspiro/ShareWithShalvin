using System.ComponentModel.DataAnnotations.Schema;

namespace AuthedContoso.Data;

[Table("Course", Schema = "contoso")]
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Price { get; set; }
}