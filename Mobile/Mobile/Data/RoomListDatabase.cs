using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mobile.Models;

namespace Mobile.Data
{
    public class RoomListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public RoomListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RoomList>().Wait();
            _database.CreateTableAsync<Cam>().Wait();
            _database.CreateTableAsync<ListCam>().Wait();
        }
        public Task<List<RoomList>> GetRoomListsAsync()
        {
            return _database.Table<RoomList>().ToListAsync();
        }
        public Task<RoomList> GetRoomListAsync(int id)
        {
            return _database.Table<RoomList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRoomListAsync(RoomList rlist)
        {
            if (rlist.ID != 0)
            {
                return _database.UpdateAsync(rlist);
            }
            else
            {
                return _database.InsertAsync(rlist);
            }
        }
        public Task<int> DeleteRoomListAsync(RoomList rlist)
        {
            return _database.DeleteAsync(rlist);
        }
        public Task<int> SaveCamAsync(Cam cam)
        {
            if (cam.ID != 0)
            {
                return _database.UpdateAsync(cam);
            }
            else
            {
                return _database.InsertAsync(cam);
            }
        }
        public Task<int> DeleteCamAsync(Cam cam)
        {
            return _database.DeleteAsync(cam);
        }
        public Task<List<Cam>> GetCamsAsync()
        {
            return _database.Table<Cam>().ToListAsync();
        }
        public Task<int> SaveListCamAsync(ListCam listc)
        {
            if (listc.ID != 0)
            {
                return _database.UpdateAsync(listc);
            }
            else
            {
                return _database.InsertAsync(listc);
            }
        }
        public Task<List<Cam>> GetListCamsAsync(int roomlistid)
        {
            return _database.QueryAsync<Cam>(
            "select C.ID, C.Description from Cam C"
            + " inner join ListCam LC"
            + " on C.ID = LC.CamID where LC.RoomListID = ?",
            roomlistid);
        }
    }
}