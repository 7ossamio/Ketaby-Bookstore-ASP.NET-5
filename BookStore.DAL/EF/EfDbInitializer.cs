using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookStore.DAL.Entities;
using BookStore.DAL.Repositories;

namespace BookStore.DAL.EF
{
    public class EfDbInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            //Start Books Initialize
            context.Books.Add(new Book { Id = 1, Name = "The Stranger", Description = "L'Étranger is a 1942 novella by French author Albert Camus. Its theme and outlook are often cited as examples of Camus' philosophy, absurdism coupled with existentialism, though Camus personally rejected the latter label.", AuthorId = 1, CategoryId = 1 });
            context.Books.Add(new Book { Id = 2, Name = "The Myth of Sisyphus", Description = "The Myth of Sisyphus is a 1942 philosophical essay by Albert Camus. Influenced by philosophers such as Søren Kierkegaard, Arthur Schopenhauer, and Friedrich Nietzsche, Camus introduces his philosophy of the absurd.", AuthorId = 1, CategoryId = 1 });
            context.Books.Add(new Book { Id = 3, Name = "Nausea ", Description = "Nausea is a philosophical novel by the existentialist philosopher Jean-Paul Sartre, published in 1938. It is Sartre's first novel and, in his own opinion, one of his best works.", AuthorId = 2, CategoryId = 1 });
            context.Books.Add(new Book { Id = 4, Name = "The Metamorphosis", Description = "The Metamorphosis tells the story of salesman Gregor Samsa, who wakes one morning to find himself inexplicably transformed into a huge insect (ungeheures Ungeziefer) and subsequently struggles to adjust to this new condition. The novella has been widely discussed among literary critics, with differing interpretations being offered. ", AuthorId = 3, CategoryId = 2 });
            context.Books.Add(new Book { Id = 5, Name = "The Castle", Description = "The Castle is a 1926 novel by Franz Kafka. In it a protagonist known only as (K.) arrives in a village and struggles to gain access to the mysterious authorities who govern it from a castle supposedly owned by Count Westwest.", AuthorId = 3, CategoryId = 3 });

            //End Books Initialize

            //Start Authors Initialize
            context.Authors.Add(new Author { Id = 1, Name = "Albert Camus" });
            context.Authors.Add(new Author { Id = 2, Name = "Jean-Paul Sartre" });
            context.Authors.Add(new Author { Id = 3, Name = "Franz Kafka" });
            //End Authors Initialize

            //Start Categories Initialize
            context.Genres.Add(new Genre { Id = 1, CategoryName = "Novel" });
            context.Genres.Add(new Genre { Id = 2, CategoryName = "political fiction" });
            context.Genres.Add(new Genre { Id = 3, CategoryName = "Mystery fiction" });
            context.Genres.Add(new Genre { Id = 4, CategoryName = "Horror" });

            //End Categories Initialize

            base.Seed(context);
        }
    }
}
