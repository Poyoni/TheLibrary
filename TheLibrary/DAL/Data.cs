namespace TheLibrary.DAL
{
    
    public class Data
    {

        string ConnectionString = "server=DESKTOP-14IT27E\\SQLEXPRESS ; initial catalog=TheLibrary ; user id=sa ; password=1234 ; TrustServerCertificate=Yes";
        //קונסטרקטור פרטי למניעת יצירת מופעים מחוץ לקלאס
        private Data()
        {
            Layer = new DataLayer(ConnectionString);
        }
        //משתנה סטטינ לשמירת מופע יחיד של המחלקה
        static Data GetData;
 
        // מאפיין סטטי לקבלת שכבת נתונים
        public static DataLayer Get
        {
            get
            {
                //יצירת מופע חדש של מחלקה במידה ולא קיים מופע
                if (GetData == null)
                {
                    GetData = new Data();

                }
                //החזרת שכבת נתנוים
                return GetData.Layer;
            }
        }
        //מאפיין לשמירת שכבת נתנוים
        public DataLayer Layer { get; set; }
    }
}
