using FitOutApplication.database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteExample
{
    public class ExerciseDatabase
    {
        private SQLiteAsyncConnection database;

        public ExerciseDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Exercise>().Wait();
        }


        public Task<List<Exercise>> GetItemsAsync()
        {
            return database.Table<Exercise>().ToListAsync();
        }

        public Task<List<Exercise>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Exercise>("SELECT * FROM [Exercise] WHERE [Done] = 0");
        }

        public Task<Exercise> GetItemAsync(int id)
        {
            return database.Table<Exercise>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Exercise item)
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

        public Task<int> DeleteItemAsync(Exercise item)
        {
            return database.DeleteAsync(item);
        }
    }
}
