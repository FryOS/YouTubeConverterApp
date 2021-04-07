using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YouTubeConverter
{
    class CommandGetInfoAndDownload : Command
    {
        Receiver receiver;
        string url = "https://youtu.be/ErdJeQTpNbg";
        string videoId = "ErdJeQTpNbg";

        YoutubeClient youtube = new YoutubeClient();

        public CommandGetInfoAndDownload
            (Receiver receiver)
        {
            this.receiver = receiver;
        }

        // Выполнить
        public override async Task<string> GetInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Команда отправлена получить информацию:");
            receiver.Operation();
            var video = await youtube.Videos.GetAsync(url);
            var title = video.Title;
            var author = video.Author;
            var duration = video.Duration;

            string text = $"Заголовок {title}\nАвтор {author}\nВремя {duration}";
            Console.ForegroundColor = ConsoleColor.White;
            return text;
        }

        // Скачать
        public override async Task<int> Download()
        {
            Console.WriteLine();
            Console.WriteLine("Команда отправлена скачать:");
            

            // Get media streams & choose the best muxed stream
            var streams = await youtube.Videos.Streams.GetManifestAsync(videoId);
            var streamInfo = streams.GetMuxed().WithHighestVideoQuality();
            if (streamInfo is null)
            {
                Console.Error.WriteLine("This videos has no streams");
                return -1;
            }

            // Compose file name, based on metadata
            var fileName = $"{videoId}.{streamInfo.Container.Name}";

            // Download video
            Console.Write($"Скачать поток: {streamInfo.VideoQualityLabel} / {streamInfo.Container.Name}... ");
            using (var progress = new InlineProgress())
                await youtube.Videos.Streams.DownloadAsync(streamInfo, fileName, progress);

            Console.WriteLine($"Видео сохранено в '{fileName}'");
            return 0;
        }
    }
}
