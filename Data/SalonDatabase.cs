using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using ProiectMediiMobile1.Models;
namespace ProiectMediiMobile1.Data
{
    public class SalonDatabase
    {
        readonly SQLite.SQLiteAsyncConnection _database;
        public SalonDatabase(string dbPath)
        {
            _database = new SQLite.SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Programare>().Wait();
            _database.CreateTableAsync<Stilist>().Wait();
            _database.CreateTableAsync<Salon>().Wait();
            _database.CreateTableAsync<Client>().Wait();
        }
        public Task<List<Salon>> GetSalonsAsync()
        {
            return _database.Table<Salon>().ToListAsync();
        }

        public Task<Salon> GetSalonAsync(int id)
        {
            return _database.Table<Salon>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveSalonAsync(Salon Salon)
        {
            if (Salon.ID != 0)
            {
                return _database.UpdateAsync(Salon);
            }
            else
            {
                return _database.InsertAsync(Salon);
            }
        }

        public Task<int> DeleteSalonAsync(Salon Salon)
        {
            return _database.DeleteAsync(Salon);
        }
        public async Task<List<Programare>> GetProgramariAsync()
        {
            var programari = await _database.Table<Programare>().ToListAsync();
            foreach (var programare in programari)
            {
                // Assuming SalonID and StilistID are foreign keys in your Programare model
                programare.Salon = await _database.Table<Salon>()
                    .Where(s => s.ID == programare.SalonID)
                    .FirstOrDefaultAsync();

                programare.Stilist = await _database.Table<Stilist>()
                    .Where(s => s.ID == programare.StilistID)
                    .FirstOrDefaultAsync();
            }
            return programari;
        }
        public Task<int> SaveProgramareAsync(Programare programare)
        {
            if (programare.ID != 0)
            {
                return _database.UpdateAsync(programare);
            }
            else
            {
                return _database.InsertAsync(programare);
            }
        }
        public Task<int> DeleteProgramareAsync(Programare programare)
        {
            return _database.DeleteAsync(programare);
        }
        public Task<List<Client>> GetClientsAsync()
        {
            return _database.Table<Client>().ToListAsync();
        }

        public Task<Client> GetClientAsync(int id)
        {
            return _database.Table<Client>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveClientAsync(Client client)
        {
            if (client.ID != 0)
            {
                return _database.UpdateAsync(client);
            }
            else
            {
                return _database.InsertAsync(client);
            }
        }

        public Task<int> DeleteClientAsync(Client client)
        {
            return _database.DeleteAsync(client);
        }
        public Task<List<Stilist>> GetStilistsAsync()
        {
            return _database.Table<Stilist>().ToListAsync();
        }

        public Task<Stilist> GetStilistAsync(int id)
        {
            return _database.Table<Stilist>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveStilistAsync(Stilist Stilist)
        {
            if (Stilist.ID != 0)
            {
                return _database.UpdateAsync(Stilist);
            }
            else
            {
                return _database.InsertAsync(Stilist);
            }
        }

        public Task<int> DeleteStilistAsync(Stilist Stilist)
        {
            return _database.DeleteAsync(Stilist);
        }
    }
}
