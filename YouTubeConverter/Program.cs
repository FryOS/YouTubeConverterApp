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
            var commandGetInfo = new CommandGetInfo(receiver);

            // инициализация команды
            sender.SetCommand(commandGetInfo);

            //  выполнение
            var res = sender.Run().GetAwaiter().GetResult();

            Console.WriteLine(res);
        }
    }
}
