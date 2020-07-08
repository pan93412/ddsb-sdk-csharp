using System;
using System.Threading.Tasks;
using ddsb_sdk;

namespace ConsoleExample
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            DDSBInfo info;

            if (args.Length < 1)
            {
                Console.WriteLine("Usage: <prog> url_to_shorten [password]");
                return 1;
            }

            try
            {
                var _ddsb = new DDSB(args[0]);
                if (args.Length >= 2) _ddsb.Password = args[1];
                info = await _ddsb.Generate();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\x1b[1m\x1b[31mSomething wrong: \x1b[0m{e.Message}");
                return 1;
            }

            Console.WriteLine($"\x1b[1mGenerated!\x1b[0m Url: {info.ShortenUrl}  Password: {info.Password}");
            return 0;
        }
    }
}
