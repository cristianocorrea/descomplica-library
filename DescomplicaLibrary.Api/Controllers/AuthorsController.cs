using DescomplicaLibrary.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DescomplicaLibrary.Api.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly DescomplicaLibraryDbContext dbContext;

    public AuthorsController(DescomplicaLibraryDbContext dbContext)
    {
        this.dbContext = dbContext;

        dbContext.Database.EnsureCreated();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
    {
        return await dbContext.Authors.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> GetAuthor(long id)
    {
        var book = await dbContext.Authors
        .Where( e => e.Id == id)
        .FirstAsync();

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }
  
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAuthor(long id, Author book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }

        var dbAuthor = await dbContext.Authors.FindAsync(id);

        if (dbAuthor == null)
        {
            return NotFound();
        }

        dbAuthor.Name = book.Name;

        await dbContext.SaveChangesAsync();

        return NoContent();
    }
   
    [HttpPost]
    public async Task<ActionResult<Author>> PostAuthor(Author book)
    {
        dbContext.Authors.Add(book);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAuthor),new { id = book.Id }, book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(long id)
    {
        var book = await dbContext.Authors.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        dbContext.Authors.Remove(book);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }

}


