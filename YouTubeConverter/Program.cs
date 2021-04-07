using System;
using System.Threading.Tasks;
using YoutubeExplode;

namespace YouTubeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // создадим отправителя
            var sender = new Sender();

            // создадим получателя
            var receiver = new Receiver();

            // создадим команду
            var command = new CommandGetInfoAndDownload(receiver);

            // инициализация команды
            sender.SetCommand(command);

            //  выполнение
            var res = sender.GetInfo().GetAwaiter().GetResult();

            Console.WriteLine(res);

            var res1 = sender.Download().GetAwaiter().GetResult();
        }
    }
}
