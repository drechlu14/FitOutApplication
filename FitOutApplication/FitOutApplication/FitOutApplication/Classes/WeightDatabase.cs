using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace FitOutApplication.Classes
{
    public class WeightDatabase
    {
        public SQLiteAsyncConnection database;

        public WeightDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Weight>().Wait();
        }
        public Task<List<Weight>> QueryCustomExist(string name)
        {
            return database.QueryAsync<Weight>("select ID FROM [Weight] where Name ='" + name + "'");
        }
        public Task<List<Weight>> QueryCustom()
        {
            return database.QueryAsync<Weight>("select * FROM [Weight]");
        }
        public Task<List<Weight>> Add()
        {
            return database.QueryAsync<Weight>("INSERT INTO [Weight] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        // Query
        public Task<List<Weight>> GetItemsAsync()
        {
            return database.Table<Weight>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Weight>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Weight>("SELECT * FROM [Weight] WHERE [Done] = 0");
        }

        // Query using LINQ <3
        public Task<Weight> GetItemAsync(int id)
        {
            return database.Table<Weight>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Weight item)
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

        public Task<int> DeleteItemAsync(Weight item)
        {
            return database.DeleteAsync(item);
        }
    }
}

