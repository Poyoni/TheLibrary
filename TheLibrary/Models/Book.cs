using System.ComponentModel.DataAnnotations;

namespace TheLibrary.Models
{
    public class Book
    {
 
        [Key]
        public int ID { get; set; }

        [Display(Name = "שם הספר")]
        public string BookName { get; set; } = string.Empty;

        [Display(Name = "גובה הספר")]
        public int height { get; set; }

        [Display(Name = "רוחב הספר")]
        public int width { get; set; }

        public Shelf Shelf { get; set; }

    }
}
