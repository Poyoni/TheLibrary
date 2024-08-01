using Microsoft.EntityFrameworkCore;
using TheLibrary.Models;

namespace TheLibrary.DAL
{
    //    DbContext קלאס שמייצג את שכבת הנתונים, יורש מקלאס 
    public class DataLayer : DbContext
    {
        // קונסטרקטור שמקבל מחרוזת חיבור ומעביר אותה לקונסטרקטור של הקלאס האב
        public DataLayer(string ConnectionString) : base(GetOptions(ConnectionString))
        {
            //יצירת מסד נתונים
            Database.EnsureCreated();

            // קריאה לפונקציה שמכניסה נתונים לטבלה במסד הנתנונים 
            Seed();

        }
        //פונקציה שצכניסה נתונים בפעם הראשונה
        private void Seed()
        {
            if (Librarys.Count() > 0)
            {
                return;
            }

            Library firstlibrary = new Library();
            firstlibrary.libraryGenre = "תורה";

            Librarys.Add(firstlibrary);
            SaveChanges();

            
            Shelf firstShelf = new Shelf();
            firstShelf.height = 30;
            firstShelf.width = 100;
            firstShelf.Library = firstlibrary;

            shelfs.Add(firstShelf);
            SaveChanges();

        

            Book firstBook = new Book();
            firstBook.BookName = "חומש בראשית";
            firstBook.height = 25;
            firstBook.width = 5;
            firstBook.Shelf = firstShelf;

            books.Add(firstBook);
            SaveChanges();
        }



        // פונקציית יצירת טבלה במסד הנתנונים
        public DbSet<Library> Librarys {  get; set; }

        public DbSet<Shelf> shelfs { get; set; }

        public DbSet<Book> books { get; set; }


        // פונקציה שמחזירה את אפשרויות התחברות למסד הנתונים
        private static DbContextOptions GetOptions(string ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), ConnectionString)
                .Options;
        }
    }  
}
