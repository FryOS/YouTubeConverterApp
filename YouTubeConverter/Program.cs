using System;
using System.Threading.Tasks;
using YoutubeExplode;

namespace YouTubeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = GetInfoAsync().GetAwaiter().GetResult();
            Console.WriteLine(value);
        }

        public static async Task<string>  GetInfoAsync()
        {
            var youtube = new YoutubeClient();
            var video = await  youtube.Videos.GetAsync("https://youtu.be/ErdJeQTpNbg");
            var title = video.Title; 
            var author = video.Author; 
            var duration = video.Duration;

            string text = $"Заголовок {title}\nАвтор {author}\nВремя {duration}";
            return text;
        }
    }
}
