using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitOutApplication.Classes
{
    public class WeightDetailDatabase
    {
        public SQLiteAsyncConnection database;

        public WeightDetailDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<WeightDetail>().Wait();
        }
        public Task<List<WeightDetail>> QueryCustomExist(string name)
        {
            return database.QueryAsync<WeightDetail>("select ID FROM [WeightDetail] where Name ='" + name + "'");
        }
        public Task<List<WeightDetail>> QueryCustom()
        {
            return database.QueryAsync<WeightDetail>("select * FROM [WeightDetail]");
        }
        public Task<List<WeightDetail>> Add()
        {
            return database.QueryAsync<WeightDetail>("INSERT INTO [WeightDetail] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        // Query
        public Task<List<WeightDetail>> GetItemsAsync()
        {
            return database.Table<WeightDetail>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<WeightDetail>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<WeightDetail>("SELECT * FROM [WeightDetail] WHERE [Done] = 0");
        }

        // Query using LINQ <3
        public Task<WeightDetail> GetItemAsync(int id)
        {
            return database.Table<WeightDetail>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(WeightDetail item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(WeightDetail item)
        {
            return database.DeleteAsync(item);
        }
    }
}
