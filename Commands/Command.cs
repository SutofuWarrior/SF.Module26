using System.Threading.Tasks;

namespace SF.Module26
{
    public abstract class Command
    {
        public abstract Task<object> Run();

        public abstract void Cancel();
    }
}
