using System.Text;

namespace Laborotorna4.service
{
    public class BooksService
    {
        public List<Books> books { get; set; }

        public BooksService(IConfiguration configuration) {

            books = configuration.GetSection("books").Get<List<Books>>() ?? new List<Books>();
        }
        public override string ToString()
        {
            StringBuilder infoBooks = new StringBuilder();
            foreach (var item in books)
            {
                infoBooks.Append(item.ToString());
            }
            return infoBooks.ToString();
        }

        public string FindByGenre(string genre)
        {
            StringBuilder info = new StringBuilder("Такий жанр відсутній");
            foreach (var book in books)
            {
                if (book.Genre == genre)
                {
                    info.Clear().Append(book.ToString());
                    break;
                }
            }
            return info.ToString();
        }
    }

    public class Books
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int Year { get; set; }
        public string Genre { get; set; } = "";
        public int Pages { get; set; }

        public override string ToString()
        {
            return $"\nInfo about books {Title}:\nAuthor - {Author}" +
                $"\nYear - {Year}\nGenre - {Genre}\nPages - {Pages}";
        }

    }
}
