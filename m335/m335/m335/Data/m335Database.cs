using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using m335.Models;

namespace m335.Data
{
    public class m335Database
    {
        readonly SQLiteAsyncConnection database;

        public m335Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<m335c>().Wait();
        }

        public Task<List<m335c>> GetNotesAsync()
        {
            //Get all notes.
            return database.Table<m335c>().OrderByDescending(m335c => m335c.ID).ToListAsync();
        }

        public Task<m335c> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<m335c>()
                .Where(m335c => m335c.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(m335c m)
        {
            if (m.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(m);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(m);
            }
        }

        public Task<int> DeleteNoteAsync(m335c m)
        {
            // Delete a note.
            return database.DeleteAsync(m);
        }
    }
}