using DescomplicaLibrary.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DescomplicaLibrary.Api.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly DescomplicaLibraryDbContext dbContext;

    public BooksController(DescomplicaLibraryDbContext dbContext)
    {
        this.dbContext = dbContext;

        dbContext.Database.EnsureCreated();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks([FromQuery] long? authorId,[FromQuery] long? genreId, [FromQuery] string? title)
    {

        var context = dbContext.Books.AsQueryable();

        if(authorId != null)
        {
            context = context.Where(e => e.AuthorId == authorId);
        }

        if(genreId != null)
        {
            context = context.Where(e => e.GenreId == genreId);
        }

        if(title != null)
        {
            context = context.Where(e => e.Title.Contains(title) );
        }

        return await context.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(long id)
    {
        var book = await dbContext.Books
        .Include(e => e.Author)
        .Include(e => e.Genre)
        .Where( e => e.Id == id)
        .FirstAsync();

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }
  
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(long id, Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }

        var dbBook = await dbContext.Books.FindAsync(id);

        if (dbBook == null)
        {
            return NotFound();
        }

        dbBook.Title = book.Title;

        await dbContext.SaveChangesAsync();

        return NoContent();
    }
   
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(Book book)
    {
        dbContext.Books.Add(book);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBook),new { id = book.Id }, book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(long id)
    {
        var book = await dbContext.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        dbContext.Books.Remove(book);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }

}


