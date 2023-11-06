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
    internal class Musicservices
    {
        private static SQL _database = new SQL();

        public void Add(Music music)
        {
            string cmd = $"INSERT INTO Artists VALUES('{music.Name}',{music.Duration})";
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

        public List<Music> GetAll()
        {

            string query = "SELECT * FROM Musics";
            DataTable table = _database.ExecuteQuery(query);

            List<Music> musics = new List<Music>();

            foreach (DataRow row in table.Rows)
            {
               Music student = new Music
                {
                    Id = (int)row["id"],
                    Name = row["name"].ToString(),
                    Duration = (int)row["durations"]
                };
               musics.Add(student);

            }
            return musics;
        }


        public void Delete(int id)
        {
            string cmd = $"DELETE FROM Musics WHERE Id={id}";

            _database.ExecuteCommand(cmd);
        }



    }
}
