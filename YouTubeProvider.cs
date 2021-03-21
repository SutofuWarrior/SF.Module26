using System.IO;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace SF.Module26
{
    public class YouTubeProvider
    {
        private readonly YoutubeClient _client = new();
        private CancellationTokenSource _cancelToken;

        public async Task<string> GetVideoInfo(string uri)
        {
            Video video = await GetVideo(uri);
            return video.ToString();
        }

        public async Task<string> DownloadVideo(string uri, string outputPath)
        {
            StreamManifest manifest = await _client.Videos.Streams.GetManifestAsync(GetVideoId(uri));
            IVideoStreamInfo streamInfo = manifest.GetMuxed().WithHighestVideoQuality();

            Video video = await GetVideo(uri);
            string file = Path.Combine(outputPath, video.Title + ".avi");
            _cancelToken = new CancellationTokenSource();

            await _client.Videos.Streams.DownloadAsync(streamInfo, file, cancellationToken: _cancelToken.Token);

            return file;
        }

        public void StopDownload() 
            => _cancelToken?.Cancel();

        private static VideoId GetVideoId(string uri)
            => new VideoId(uri);

        private async Task<Video> GetVideo(string uri) 
            => await _client.Videos.GetAsync(GetVideoId(uri));
    }
}
