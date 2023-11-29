using System.Collections.Generic;
using System.Linq;

namespace LivreProjet
{
    public abstract class Category
    {
        public abstract string Name { get; set; }
        protected List<Book> Books { get; }

        protected Category()
        {
            Books = new List<Book>();
        }

        public virtual void AddBook(Book book) // Marquer la méthode comme virtual
        {
            Books.Add(book);
            // Logique d'ajout de livre à la catégorie
        }

        public virtual void RemoveBook(Book book) // Marquer la méthode comme virtual
        {
            Books.Remove(book);
            // Logique de suppression du livre de la catégorie
        }

        public List<Book> GetBooksSortedByTitle()
        {
            var sortedBooks = Books.OrderBy(book => book).ToList();
            return sortedBooks;
        }
    }

    public class BookCategory : Category
    {
        public override string Name { get; set; } // Ajoute un accesseur en écriture

        private List<Book> books = new List<Book>();

        // ... Autres fonctionnalités spécifiques à BookCategory

        public override void AddBook(Book book) // Redéfinition de la méthode AddBook
        {
            base.AddBook(book);
            // Logique spécifique à l'ajout de livre dans BookCategory
        }

        public override void RemoveBook(Book book) // Redéfinition de la méthode RemoveBook
        {
            base.RemoveBook(book);
            // Logique spécifique à la suppression de livre dans BookCategory
        }
    }
}
