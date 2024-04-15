using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DescomplicaLibrary.Api.Models;

public class Book
{
    [Key]
    public long Id { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public DateTime ReleaseDate { get; set; }


    [ForeignKey("AuthorId")]
    public virtual  Author Author { get; set; } = null!;

    public long AuthorId { get; set; }

    
    [ForeignKey("GenreId")]
    public virtual  Genre Genre { get; set; } = null!;
    
    public long GenreId { get; set; }

}
