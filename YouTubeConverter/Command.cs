using System.Threading.Tasks;

namespace YouTubeConverter
{
    abstract class Command
    {
        public abstract Task<string> GetInfo();
        public abstract Task<int> Download();
    }
}
