using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Mobile.Models
{
    public class ListCam
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(RoomList))]
        public int RoomListID { get; set; }
        public int CamID
        {
            get; set;

        }
    }
}
