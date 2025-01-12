using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProiectMAUI.Models;
using SQLiteNetExtensions.Attributes;

namespace ProiectMAUI.Models
{
    public class TattooList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250), Unique]
        public string Description {  get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(typeof(Parlor))]
        public int ParlorID {  get; set; }
    }
}
