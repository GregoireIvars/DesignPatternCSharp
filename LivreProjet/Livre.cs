
using System;


namespace LivreProjet
{
    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Category BookCategory { get; set; }

        public Book(string title, string author, Category bookCategory)
        {
            Title = title;
            Author = author;
            BookCategory = bookCategory;
        }

        public int CompareTo(Book? other)
        {
            if (other == null) return 1;
            return string.Compare(this.Title, other.Title, StringComparison.Ordinal);
        }
    }

    public interface IBook // Convention : nom d'interface en majuscule
    {
        Book CreateBook(string title, string author, Category category);
    }

    public class BookFactory : IBook
    {
        public Book CreateBook(string title, string author, Category category)
        {
            return new Book(title, author, category);
        }
    }
}