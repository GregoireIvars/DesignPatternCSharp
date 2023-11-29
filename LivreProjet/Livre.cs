
using System;


namespace LivreProjet
{
    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Category BookCategory { get; set; }
        public bool IsReserved { get; private set; }

        public void Reserve()
        {
            IsReserved = true;
        }
        public void CancelReservation()
        {
            IsReserved = false;
        }

        public Book(string title, string author, Category bookCategory)
        {
            Title = title;
            Author = author;
            BookCategory = bookCategory;

            IsReserved = false;
        }

        public int CompareTo(Book? other)
        {
            if (other == null) return 1;
            return string.Compare(this.Title, other.Title, StringComparison.Ordinal);
        }
        public void ReserveBook()
        {
            if (!IsReserved)
            {
                IsReserved = true;
                Console.WriteLine("Livre réservé !");
            }
            else
            {
                Console.WriteLine("Désolé, ce livre est déjà réservé.");
            }
        }
    }

    public interface IBook 
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