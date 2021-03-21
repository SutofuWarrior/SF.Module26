using System.Threading.Tasks;

namespace SF.Module26
{
    public class YouTubeDownloadCommand : Command
    {
        private readonly string _uri;
        private readonly string _path;
        private readonly YouTubeProvider _provider;

        public YouTubeDownloadCommand(YouTubeProvider provider, string uri, string path)
        {
            _provider = provider;
            _uri = uri;
            _path = path;
        }

        public override async Task<object> Run() 
            => await _provider.DownloadVideo(_uri, _path);

        public override void Cancel() 
            => _provider.StopDownload();
    }
}
