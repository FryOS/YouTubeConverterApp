using System;
using System.Threading.Tasks;
using YoutubeExplode;

namespace YouTubeConverter
{
    class CommandGetInfo : Command
    {
        Receiver receiver;

        public CommandGetInfo(Receiver receiver)
        {
            this.receiver = receiver;
        }

        // Выполнить
        public override async Task<string> GetInfo()
        {
            Console.WriteLine("Команда отправлена получить информацию");
            receiver.Operation();
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync("https://youtu.be/ErdJeQTpNbg");
            var title = video.Title;
            var author = video.Author;
            var duration = video.Duration;

            string text = $"Заголовок {title}\nАвтор {author}\nВремя {duration}";
            return text;
        }

        // Скачать
        public override void Download()
        { }
    }
}
