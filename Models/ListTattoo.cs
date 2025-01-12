using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectMAUI.Models
{
    public class ListTattoo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }


        [ForeignKey(typeof(TattooList))]
        public int TattooListID { get; set; }
        public int TattooID { get; set; }
    }
}
