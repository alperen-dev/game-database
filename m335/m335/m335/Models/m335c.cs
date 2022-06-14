using System;
using SQLite;

namespace m335.Models
{
    public class m335c
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Dev { get; set; }
        public DateTime Date { get; set; }
    }
}