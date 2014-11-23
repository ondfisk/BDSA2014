using System.Threading.Tasks;

namespace Lecture07
{
    class Fail
    {
        static void MainFail(string[] args)
        {
            var t = Task.Run(() => string.Join(null, null));

            t.Wait();
        }
    }
}
