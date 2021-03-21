using System;
using System.Threading.Tasks;
using YoutubeExplode;

namespace SF.Module26
{
    class Program
    {
        static async Task Main()
        {
            var provider = new YouTubeProvider();
            var downloader = new YoutubeDownloader();

            Console.WriteLine("Укажите ссылку на видео:");
            string uri = Console.ReadLine();

            Console.WriteLine();
            downloader.SetCommand(new YouTubeGetInfoCommand(provider, uri));

            string info = await downloader.Run() as string;
            Console.WriteLine(info);

            downloader.SetCommand(new YouTubeDownloadCommand(provider, uri, AppDomain.CurrentDomain.BaseDirectory));

            string file = await downloader.Run() as string;
            Console.WriteLine("Загружено:");
            Console.WriteLine(file);

            Console.ReadKey();
        }
    }
}
