using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public override void GetInfo()
        {
            Console.WriteLine("Команда отправлена получить информацию");
            receiver.Operation();
        }

        // Скачать
        public override void Download()
        { }
    }
}
