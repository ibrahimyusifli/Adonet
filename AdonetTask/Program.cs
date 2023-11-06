using AdonetTask.Models;
using AdonetTask.Services;
using System.Data.SqlClient;

namespace AdonetTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conn = "server=DESKTOP-OD15AGH\\SQLEXPRESS;database=Musicibo;trusted_connection=true;integrated security=true;";

            Artistservices service = new Artistservices();
            Artist artist = new Artist { Name = "Raisa", Surname = "Yusifli", Birthday=17 ,Gender="Male" };
            service.Add(artist);
            service.Delete(2);


            List<Artist> artists = service.GetAll();

            foreach (Artist item in artists)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Surname} {item.Birthday} {item.Gender}");
            }







            Musicservices musicservices = new Musicservices();
            Music music = new Music {Name="Fairytale",Duration=240};
            service.Add(music);
            service.Delete(2);


            List<Music> musics = service.GetAll();

            foreach (Music item  in musics)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Duration} ");
            }






        }
    }
}
