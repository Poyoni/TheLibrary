using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLibrary.Models
{
    public class Library
    {
        public Library()
        {
            shelfs = new List<Shelf>();
        }
        [Key]
        public int ID { get; set; }

        [Display(Name = "ז'אנר")]
        public string libraryGenre { get; set; } = string.Empty;

        public List<Shelf> shelfs { get; set; }

    }

}
