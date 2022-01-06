using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mobile.Models
{
    public class RoomList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
