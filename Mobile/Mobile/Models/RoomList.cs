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
        public string Name { get; set; }
        
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }


        

       
   

    }
}
