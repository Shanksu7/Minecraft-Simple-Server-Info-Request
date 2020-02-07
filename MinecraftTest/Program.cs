using MinecraftTest.MinecraftAPI;
using System;
using System.Threading.Tasks;

namespace MinecraftTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = await MinecraftServer.GetServer("45.35.93.194:25617");
            if(server.Online)
                Console.WriteLine("Servidor online!");
            else
                Console.WriteLine("Esta off");
        }
    }
}
