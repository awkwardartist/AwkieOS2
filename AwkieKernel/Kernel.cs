using System;
using System.Net;
using System.IO;
using System.Reflection.Emit;
using Sys = Cosmos.System;

namespace AwkieKernel
{
    public class Kernel : Sys.Kernel
    {
        WebClient client = new WebClient();
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Boot Success!!");
            Console.WriteLine("Setting up VFS");
            
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            
           
            
        }

        protected override void Run()
        {
            
            
            Console.WriteLine("root Dirs:");
            foreach(var volume in fs.GetVolumes())
            {
                Console.WriteLine(volume.mName);
                Console.WriteLine("size:");
                Console.WriteLine(volume.mSize);

            }
            Console.WriteLine("\n\n");
            Console.WriteLine("creating necissary files in boot filesystem...");

            Console.WriteLine("creating a new filesystem...");
            
            
            Console.ReadKey();
        }
    }
}