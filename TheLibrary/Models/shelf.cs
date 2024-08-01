using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLibrary.Models
{
    public class Shelf
    {
        public Shelf()
        {
            books = new List<Book>();
        }
        [Key]
        public int ID { get; set; }

        [Display(Name = "גובה המדף")]
        public int height { get; set; }

        [Display(Name = "רוחב המדף")]
        public int width { get; set; }

        public List<Book> books { get; set; }

        public Library Library { get; set; }

    }

}
