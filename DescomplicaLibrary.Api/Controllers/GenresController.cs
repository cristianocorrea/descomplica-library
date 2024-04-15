using DescomplicaLibrary.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DescomplicaLibrary.Api.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    private readonly DescomplicaLibraryDbContext dbContext;

    public GenresController(DescomplicaLibraryDbContext dbContext)
    {
        this.dbContext = dbContext;

        dbContext.Database.EnsureCreated();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
    {
        return await dbContext.Genres.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Genre>> GetGenre(long id)
    {
        var book = await dbContext.Genres
        .Where( e => e.Id == id)
        .FirstAsync();

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }
  
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGenre(long id, Genre book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }

        var dbGenre = await dbContext.Genres.FindAsync(id);

        if (dbGenre == null)
        {
            return NotFound();
        }

        dbGenre.Name = book.Name;

        await dbContext.SaveChangesAsync();

        return NoContent();
    }
   
    [HttpPost]
    public async Task<ActionResult<Genre>> PostGenre(Genre book)
    {
        dbContext.Genres.Add(book);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGenre),new { id = book.Id }, book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenre(long id)
    {
        var book = await dbContext.Genres.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        dbContext.Genres.Remove(book);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }

}


