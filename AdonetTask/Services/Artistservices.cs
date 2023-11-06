using AdonetTask.Data;
using AdonetTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdonetTask.Services
{
    internal class Artistservices
    {
        private static SQL _database = new SQL();

        public void Add(Artist artist )
        {
            string cmd = $"INSERT INTO Artists VALUES('{artist.Name}','{artist.Surname}',{artist.Birthday},'{artist.Gender}')";
            int result = _database.ExecuteCommand(cmd);

            if (result > 0)
            {
                Console.WriteLine("Command successfully completed");
            }
            else
            {
                Console.WriteLine("Error occured");
            }
        }

        

        public List<Artist> GetAll()
        
          {

            string query = "SELECT * FROM Students";
        DataTable table = _database.ExecuteQuery(query);

        List<Artist> artists = new List<Artist>();

            foreach (DataRow row in table.Rows)
            {
               Artist artist = new Artist
                {
                    Id = (int)row["id"],
                    Name = row["name"].ToString(),
                    Surname = row["surname"].ToString(),
                   Birthday = (int)row["birtday"],
                   Gender = row["gender"].ToString()

                };
       artists.Add(artist);

            }
            return artists;
        }

        public void Delete(int id)
        {
            string cmd = $"DELETE FROM Artists WHERE Id={id}";

            _database.ExecuteCommand(cmd);
        }

        internal void Add(Music music)
        {
            throw new NotImplementedException();
        }
    }

    
}
