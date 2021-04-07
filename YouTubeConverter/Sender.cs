using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeConverter
{
    class Sender
    {
        Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        // Выполнить
        public async Task<string> GetInfo()
        {
           return await _command.GetInfo();
        }

        // Отменить
        public async Task<int> Download()
        {
            return await _command.Download();
        }
    }
}
