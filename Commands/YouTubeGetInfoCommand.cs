using System.Threading.Tasks;

namespace SF.Module26
{
    public class YouTubeGetInfoCommand : Command
    {
        private readonly string _uri;
        private readonly YouTubeProvider _provider;

        public YouTubeGetInfoCommand(YouTubeProvider provider, string uri)
        {
            _provider = provider;
            _uri = uri;
        }

        public override async Task<object> Run() 
            => await _provider.GetVideoInfo(_uri);

        public override void Cancel() { }
    }
}
