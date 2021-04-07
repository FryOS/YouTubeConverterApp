using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeConverter
{
    abstract class Command
    {
        public abstract Task<string> GetInfo();
        public abstract void Download();
    }
}
