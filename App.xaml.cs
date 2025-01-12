using System;
using ProiectMAUI.Data;
using System.IO;

namespace ProiectMAUI
{
    public partial class App : Application
    {
        static TattooListDatabase database;
        public static TattooListDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new TattooListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TattooList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
