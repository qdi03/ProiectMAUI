using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMAUI.Models
{
    public class Parlor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ParlorName { get; set; }
        public string Adress { get; set; }
        public string ShopDetails
        {
            get
            {
                return ParlorName + " "+Adress;
            } }

        
        [OneToMany]
        public List<TattooList> TattooLists { get; set; }

    }
}
