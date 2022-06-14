using System;
using System.IO;
using m335;
using m335.Data;
using Xamarin.Forms;
using SQLite;

namespace m335
{
    public partial class App : Application
    {
        static m335Database database;

        // Create the database connection as a singleton.
        public static m335Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new m335Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m335.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}