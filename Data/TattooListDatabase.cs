using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectMAUI.Models;

namespace ProiectMAUI.Data
{
    public class TattooListDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public TattooListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TattooList>().Wait();
        }
        public Task<List<TattooList>> GetTattooListsAsync()
        {
            return _database.Table<TattooList>().ToListAsync();
        }
        public Task<TattooList> GetTattooListAsync(int id)
        {
            return _database.Table<TattooList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveTattooListAsync(TattooList tlist)
        {
            if (tlist.ID != 0)
            {
                return _database.UpdateAsync(tlist);
            }
            else
            {
                return _database.InsertAsync(tlist);
            }
        }
        public Task<int> DeleteTattooListAsync(TattooList tlist)
        {
            return _database.DeleteAsync(tlist);
        }

    }
}