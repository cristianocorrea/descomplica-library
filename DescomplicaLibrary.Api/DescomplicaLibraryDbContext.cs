using DescomplicaLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DescomplicaLibrary.Api;

public class DescomplicaLibraryDbContext : DbContext
{
    public DescomplicaLibraryDbContext(DbContextOptions<DescomplicaLibraryDbContext> options): base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)    
    {

       base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Fiction" },
            new Genre { Id = 2, Name = "Fantasy" },
            new Genre { Id = 3, Name = "Romance" }
            );

        modelBuilder.Entity<Author>().HasData(
            new Genre { Id = 1, Name = "Kristen Perrin" },
            new Genre { Id = 2, Name = "Percival Everett" },
            new Genre { Id = 3, Name = "Holly Black" },
            new Genre { Id = 4, Name = "Scarlett St. Clair" },
            new Genre { Id = 5, Name = "Lynn Painter" }
            );

       modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "How to Solve Your Own Murder", AuthorId = 1, GenreId= 1, Description = "For fans of Knives Out and The Thursday Murder Club , an enormously fun mystery about a woman who spends her entire life trying to prevent her foretold murder only to be proven right sixty years later, when she is found dead in her sprawling country estate... Now it's up to her great-niece to catch the killer. " },
            new Book { Id = 2, Title = "James", AuthorId = 2, GenreId= 1, Description = "A brilliant, action-packed reimagining of The Adventures of Huckleberry Finn , both harrowing and ferociously funny, told from the enslaved Jim's point of view. When the enslaved Jim overhears that he is about to be sold to a man in New Orleans, separated from his wife and daughter forever, he decides to hide on nearby Jackson Island until he can formulate a plan. Meanwhile, Huck Finn has faked his own death to escape his violent father, recently returned to town. As all readers of American literature know, thus begins the dangerous and transcendent journey by raft down the Mississippi River toward the elusive and too-often-unreliable promise of the Free States and beyond. While many narrative set pieces of The Adventures of Huckleberry Finn remain in place (floods and storms, stumbling across both unexpected death and unexpected treasure in the myriad stopping points along the rivers banks, encountering the scam artists posing as the Duke and Dauphin…), Jims agency, intelligence and compassion are shown in a radically new light. " },
            new Book { Id = 3, Title = "The Prisoners Throne", AuthorId = 3, GenreId= 2, Description = "Prince Oak is paying for his betrayal. Imprisoned in the icy north and bound to the will of a monstrous new queen, he must rely on charm and calculation to survive. With High King Cardan and High Queen Jude willing to use any means necessary to retrieve their stolen heir, Oak will have to decide whether to attempt regaining the trust of the girl hes always loved or to remain loyal to Elfhame and hand over the means to end her reign—even if it means ending Wren, too. " },
            new Book { Id = 4, Title = "A Touch of Chaos", AuthorId = 4, GenreId= 2, Description = "Persephone, Goddess of Spring, never guessed a chance encounter with Hades, God of the Underworld, would change her life forever—but he did." },
            new Book { Id = 5, Title = "Happily Never After", AuthorId = 5, GenreId= 3, Description = "When Sophie Steinbeck finds out just before her nuptials that her fiancé has cheated yet again, she desperately wants to call it off. But because her future father-in-law is her dads cutthroat boss, she doesnt want to be the one to do it. Her savior comes in the form of a professional objector, whose purpose is to show up at weddings and proclaim the words no couple (usually) wants to hear at their ceremony: “I object!” " },
            new Book { Id = 6, Title = "The Love Wager", AuthorId = 5, GenreId= 3, Description = "Hallie Piper is turning over a new leaf. After belly-crawling out of a hotel room (hello, rock bottom), she decides its time to become a full-on adult. " },
            new Book { Id = 7, Title = "Wes & Lizs College Road Trip", AuthorId = 5, GenreId= 3, Description = "Sucesso no TikTok, Melhor do que nos filmes ganha capítulos extras inéditos com muito romance e Taylor Swift Depois de viver uma história de amor digna das comédias românticas em Melhor do que nos filmes , Elizabeth Buxbaum e Wesley Bennett estão a caminho da Universidade da Califórnia. Mas Liz não tem pressa, porque botar o pé na estrada com Wes e rir de suas piadas é mais divertido do que qualquer outra coisa no mundo. À medida que cruzam o país e veem lindas paisagens pela janela do carro, Wes e Liz vão criar uma trilha sonora, resgatar um gato abandonado na estrada, se envolver em confusão, dar muitos beijos e talvez até encontrar coragem para dizer aquelas três palavras mágicas. Mas os dois sabem que, quando chegarem ao destino, nada será como antes. Ao deixar a cidade natal e a adolescência para trás, eles também estão abrindo as portas para novas possibilidades, e o futuro pode ser surpreendente. Um inesquecível presente para os fãs, Wes e Liz na estrada tem cinco capítulos extras inéditos com referências a músicas de Taylor Swift e muitos momentos apaixonantes. Pela primeira vez, Lynn Painter traz o ponto de vista de Wes e revela o que aconteceu após os eventos de Melhor do que nos filmes . " }
            );
    }
}