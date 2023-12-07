using System;
using System.Collections.Generic;
using System.Linq;

public class Author
{
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
}

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
}

class Program
{
    static void Main()
    {
        List<Author> authors = new List<Author>
        {
            new Author { AuthorId = 1, AuthorName = "John Doe"},
            new Author { AuthorId = 2, AuthorName = "Jane Smith"},
            new Author { AuthorId = 3, AuthorName = "Jane Man" }
        };

        var aurt = authors.Where(x => x.AuthorName.Contains("Jo"));

        List<Book> books = new List<Book>
        {
            new Book { BookId = 1, Title = "Book 1", AuthorId = 1 },
            new Book { BookId = 2, Title = "Book 2", AuthorId = 1 },
            new Book { BookId = 3, Title = "Book 3", AuthorId = 2 },
            new Book { BookId = 4, Title = "Book 4", AuthorId = 2 },
            new Book { BookId = 5, Title = "Book 5", AuthorId = 2 }
        };

        var query = authors.GroupJoin(
            books,
            author => author.AuthorId,
            book => book.AuthorId,
            (author, bookGroup) => new
            {
                Author = author,
                Books = bookGroup.DefaultIfEmpty()
            }
        );
        var query1 = authors.Join(
            books,
            author => author.AuthorId,
            book => book.AuthorId,
            (author, bookGroup) => new
            {
                Author = author,
                Books = bookGroup
            }
        );
        var query2 = books.ToLookup( book => book.AuthorId, book => new { book, book.AuthorId } );
        var query3 = from author in authors
                    join book in books on author.AuthorId equals book.AuthorId into bookGroup
                    select new
                    {
                        Author = author,
                        Books = bookGroup.DefaultIfEmpty()
                    };
        var qwe = query.Concat(query3);
        var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var lookup = numbers.ToLookup(n => n % 2);
        var groupBy = numbers.GroupBy(n => n % 2);
    }
}
