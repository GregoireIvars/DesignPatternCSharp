using System;
using System.Collections.Generic;

namespace LivreProjet
{
    class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque bibliotheque = new Bibliotheque();

            Category fictionCategory = new BookCategory { Name = "Fiction" };
            Category nonFictionCategory = new BookCategory { Name = "Non-Fiction" };
            Category policierCategory = new BookCategory { Name = "Policier" };

            bibliotheque.AddCategory(fictionCategory);
            bibliotheque.AddCategory(nonFictionCategory);
            bibliotheque.AddCategory(policierCategory);

            BookFactory bookFactory = new BookFactory();
            fictionCategory.AddBook(bookFactory.CreateBook("1984", "George Orwell", fictionCategory));
            fictionCategory.AddBook(bookFactory.CreateBook("Brave New World", "Aldous Huxley", fictionCategory));
            nonFictionCategory.AddBook(bookFactory.CreateBook("Sapiens", "Yuval Noah Harari", nonFictionCategory));
            nonFictionCategory.AddBook(bookFactory.CreateBook("The Selfish Gene", "Richard Dawkins", nonFictionCategory));

            DisplayBooksByCategory(bibliotheque);

            Console.ReadLine();
        }

        static void DisplayBooksByCategory(Bibliotheque bibliotheque)
        {
            bool isValidCategory = false;

            while (!isValidCategory)
            {
                Console.WriteLine("Quelle catégorie de livres voulez-vous voir ?");
                Console.WriteLine("1. Fiction");
                Console.WriteLine("2. Non-Fiction");
                Console.WriteLine("3. Policier");
                Console.Write("Entrez le numéro de la catégorie : ");

                string userInput = Console.ReadLine();

                Category selectedCategory;
                switch (userInput)
                {
                    case "1":
                        selectedCategory = bibliotheque.Categories.FirstOrDefault(cat => cat.Name == "Fiction");
                        break;
                    case "2":
                        selectedCategory = bibliotheque.Categories.FirstOrDefault(cat => cat.Name == "Non-Fiction");
                        break;
                    case "3":
                        selectedCategory = bibliotheque.Categories.FirstOrDefault(cat => cat.Name == "Policier");
                        break;
                    default:
                        selectedCategory = null;
                        break;
                }

                if (selectedCategory != null)
                {
                    List<Book> books = selectedCategory.GetBooksSortedByTitle();
                    Console.WriteLine($"Livres de la catégorie '{selectedCategory.Name}' :");
                    for (int i = 0; i < books.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Titre : {books[i].Title}, Auteur : {books[i].Author}, Réservé : {(books[i].IsReserved ? "Oui" : "Non")}");
                    }

                    // Demande à l'utilisateur de choisir un livre
                    Console.Write("Choisissez le numéro du livre (0 pour revenir en arrière, -1 pour retourner un livre) : ");
                    if (int.TryParse(Console.ReadLine(), out int bookChoice))
                    {
                        if (bookChoice == -1)
                        {
                            Console.Write("Entrez le titre du livre à retourner : ");
                            string bookTitleToReturn = Console.ReadLine();

                            Book bookToReturn = books.FirstOrDefault(book => book.Title.Equals(bookTitleToReturn, StringComparison.OrdinalIgnoreCase));
                            if (bookToReturn != null && bookToReturn.IsReserved)
                            {
                                bookToReturn.CancelReservation(); // Annuler la réservation
                                Console.WriteLine("Livre retourné avec succès !");
                            }
                            else
                            {
                                Console.WriteLine("Livre non réservé ou introuvable.");
                            }
                        }
                        else if (bookChoice > 0 && bookChoice <= books.Count)
                        {
                            Book selectedBook = books[bookChoice - 1];
                            if (!selectedBook.IsReserved)
                            {
                                selectedBook.Reserve(); // Réserver le livre
                                Console.WriteLine("Livre réservé avec succès !");
                            }
                            else
                            {
                                Console.WriteLine("Ce livre est déjà réservé.");
                            }
                        }
                        else if (bookChoice == 0)
                        {
                            break; // Retourner en arrière
                        }
                        else
                        {
                            Console.WriteLine("Choix invalide.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrée invalide.");
                    }
                }
                else
                {
                    Console.WriteLine("Catégorie invalide. Veuillez réessayer.");
                }
            }
        }
    }
}