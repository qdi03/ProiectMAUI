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
            _database.CreateTableAsync<Tattoo>().Wait();
            _database.CreateTableAsync<ListTattoo>().Wait();
            _database.CreateTableAsync<Parlor>().Wait();
        }

        public Task<int>SaveTattooAsync(Tattoo tattoo)
        {
            if(tattoo.ID != 0)
            {
                return _database.UpdateAsync(tattoo);
            }
            else
            {
                return _database.InsertAsync(tattoo);
            }
        }

        public Task<int> DeleteTattooAsync(Tattoo tattoo)
        {
            return _database.DeleteAsync(tattoo);
        }

        public Task<List<Tattoo>> GetTattoosAsync()
        {
            return _database.Table<Tattoo>().ToListAsync();
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

        public Task<int> SaveListTattooAsync(ListTattoo listt)
        {
            if (listt.ID != 0)
            {
                return _database.UpdateAsync(listt);
            }
            else
            {
                return _database.InsertAsync(listt);
            }
        }
        public Task<List<Tattoo>> GetListTattoosAsync(int tattoolistid)
        {
            return _database.QueryAsync<Tattoo>(
            "select T.ID, T.Description from Tattoo T"
            + " inner join ListTattoo LT"
            + " on T.ID = LT.TattooID where LT.TattooListID = ?",
            tattoolistid);
        }

        public Task<ListTattoo> GetListTattooByIdsAsync(int tattooListId, int tattooId)
        {
            return _database.FindAsync<ListTattoo>(lt => lt.TattooListID == tattooListId && lt.TattooID == tattooId);
        }

        public Task<int> DeleteListTattooAsync(ListTattoo listTattoo)
        {
            return _database.DeleteAsync(listTattoo);
        }

        public Task<List<Parlor>> GetParlorsAsync()
        {
            return _database.Table<Parlor>().ToListAsync();
        }
        public Task<int> SaveParlorAsync(Parlor parlor)
        {
            if (parlor.ID != 0)
            {
                return _database.UpdateAsync(parlor);
            }
            else
            {
                return _database.InsertAsync(parlor);
            }
        }
    }
}