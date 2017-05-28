using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace FitOutApplication.Classes
{
    public class FatDatabase
    {
        public SQLiteAsyncConnection database;

        public FatDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Fat>().Wait();
        }
        public Task<List<Fat>> QueryCustomExist(string name)
        {
            return database.QueryAsync<Fat>("select ID FROM [Fat] where Name ='" + name + "'");
        }
        public Task<List<Fat>> QueryCustom()
        {
            return database.QueryAsync<Fat>("select * FROM [Fat]");
        }
        public Task<List<Fat>> Add()
        {
            return database.QueryAsync<Fat>("INSERT INTO [Fat] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        // Query
        public Task<List<Fat>> GetItemsAsync()
        {
            return database.Table<Fat>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Fat>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Fat>("SELECT * FROM [Fat] WHERE [Done] = 0");
        }

        // Query using LINQ <3
        public Task<Fat> GetItemAsync(int id)
        {
            return database.Table<Fat>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Fat item)
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

        public Task<int> DeleteItemAsync(Fat item)
        {
            return database.DeleteAsync(item);
        }
    }
}

