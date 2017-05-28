using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace FitOutApplication.Classes
{
    public class BellyDatabase
    {
        public SQLiteAsyncConnection database;

        public BellyDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Belly>().Wait();
        }
        public Task<List<Belly>> QueryCustomExist(string name)
        {
            return database.QueryAsync<Belly>("select ID FROM [Belly] where Name ='" + name + "'");
        }
        public Task<List<Belly>> QueryCustom()
        {
            return database.QueryAsync<Belly>("select * FROM [Belly]");
        }
        public Task<List<Belly>> Add()
        {
            return database.QueryAsync<Belly>("INSERT INTO [Belly] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        // Query
        public Task<List<Belly>> GetItemsAsync()
        {
            return database.Table<Belly>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Belly>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Belly>("SELECT * FROM [Belly] WHERE [Done] = 0");
        }

        // Query using LINQ <3
        public Task<Belly> GetItemAsync(int id)
        {
            return database.Table<Belly>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Belly item)
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

        public Task<int> DeleteItemAsync(Belly item)
        {
            return database.DeleteAsync(item);
        }
    }
}

