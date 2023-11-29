using System;
using System.Collections.Generic;

namespace LivreProjet
{
    class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque bibliotheque = new Bibliotheque();

            // Création de catégories
            Category fictionCategory = new BookCategory();
            Category nonFictionCategory = new BookCategory();
            Category policier = new BookCategory();

            bibliotheque.AddCategory(fictionCategory);
            bibliotheque.AddCategory(nonFictionCategory);
            bibliotheque.AddCategory(policier);

            // Ajout de livres dans les catégories
            BookFactory bookFactory = new BookFactory();

            fictionCategory.AddBook(bookFactory.CreateBook("1984", "George Orwell", fictionCategory));
            fictionCategory.AddBook(bookFactory.CreateBook("Brave New World", "Aldous Huxley", fictionCategory));
            nonFictionCategory.AddBook(bookFactory.CreateBook("Sapiens", "Yuval Noah Harari", nonFictionCategory));
            nonFictionCategory.AddBook(bookFactory.CreateBook("The Selfish Gene", "Richard Dawkins", nonFictionCategory));

            // Affichage des livres triés par titre
            List<Book> allBooks = bibliotheque.GetAllBooksSortedByTitle();

            Console.WriteLine("Livres triés par titre :");
            foreach (var book in allBooks)
            {
                Console.WriteLine($"Titre : {book.Title}, Auteur : {book.Author}, Catégorie : {(book.BookCategory as BookCategory)?.Name}");
            }

            Console.ReadLine();
        }
    }
}