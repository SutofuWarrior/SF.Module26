using System;
using System.Threading.Tasks;

namespace SF.Module26
{
    public class YoutubeDownloader
    {
        private Command _command;

        public void SetCommand(Command c)
        {
            _command = c;
        }

        public async Task<object> Run() 
            => await _command.Run();

        public void Stop()
        {
            Console.Write("Прерывание задачи... ");
            _command.Cancel();
            Console.WriteLine("готово");
        }
    }
}
