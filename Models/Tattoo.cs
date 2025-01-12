using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace ProiectMAUI.Models
{
    public class Tattoo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Description { get; set; }


        [OneToMany]
        public List<ListTattoo> ListTattoos { get; set; }
    }
}
