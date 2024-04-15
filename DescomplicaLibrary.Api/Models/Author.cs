using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DescomplicaLibrary.Api.Models;

public class Author
{
    [Key]
    public long Id { get; set; }

    [Column(TypeName = "varchar(200)")]
    public required string Name { get; set; }
}
