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

        public virtual void AddBook(Book book) // Marquer la m�thode comme virtual
        {
            Books.Add(book);
            // Logique d'ajout de livre � la cat�gorie
        }

        public virtual void RemoveBook(Book book) // Marquer la m�thode comme virtual
        {
            Books.Remove(book);
            // Logique de suppression du livre de la cat�gorie
        }

        public List<Book> GetBooksSortedByTitle()
        {
            var sortedBooks = Books.OrderBy(book => book).ToList();
            return sortedBooks;
        }
    }

    public class BookCategory : Category
    {
        public override string Name { get; set; } // Ajoute un accesseur en �criture

        private List<Book> books = new List<Book>();

        // ... Autres fonctionnalit�s sp�cifiques � BookCategory

        public override void AddBook(Book book) // Red�finition de la m�thode AddBook
        {
            base.AddBook(book);
            // Logique sp�cifique � l'ajout de livre dans BookCategory
        }

        public override void RemoveBook(Book book) // Red�finition de la m�thode RemoveBook
        {
            base.RemoveBook(book);
            // Logique sp�cifique � la suppression de livre dans BookCategory
        }
    }
}
