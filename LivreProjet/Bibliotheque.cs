using System.Collections.Generic;

namespace LivreProjet
{
    public  class Bibliotheque
    {
        private List<Category> categories = new List<Category>();

        public List<Category> Categories => categories;

        public void AddCategory(Category category)
        {
            categories.Add(category);
        }




        public List<Book> GetAllBooksSortedByTitle()
        {
            List<Book> allBooks = new List<Book>();
            foreach (var category in categories)
            {
                allBooks.AddRange(category.GetBooksSortedByTitle());
            }

            return allBooks.OrderBy(book => book).ToList();
        }
    }
}