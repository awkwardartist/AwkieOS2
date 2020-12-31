using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Threading;
using Sys = Cosmos.System;

namespace AwkieKernel
{
    public class Kernel : Sys.Kernel
    {
        public Sys.FileSystem.FileSystemFactory systemFactory;
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Boot Success!!");
            

        }
        
        protected override void Run()
        {
            Devices:
            Console.WriteLine("I detect: " + Cosmos.HAL.BlockDevice.Partition.Devices.Count + " partition devices, please choose\none for your filesystem to go in:");
            foreach(var part in Cosmos.HAL.BlockDevice.Partition.Devices)
            {
                Console.WriteLine(part);
            }

            Console.Write(">>");
            Cosmos.HAL.BlockDevice.BlockDevice blockdevice = Cosmos.HAL.BlockDevice.Partition.Devices[0];
            string name = Console.ReadLine();
            bool def = true;
            foreach (var part in Cosmos.HAL.BlockDevice.Partition.Devices)
            {
                if (name == part.ToString())
                {
                    blockdevice = part;
                    def = false;
                }
            }
            if (def)
            {
            def:
                Console.WriteLine("your name didnt match any listed block devices,\nretry or go with default (" + Cosmos.HAL.BlockDevice.Partition.Devices[0] + ") type retry / cont");
                Console.Write(">>");
                var input = Console.ReadLine();
                if(input == "retry")
                {
                    goto Devices;
                } else if(input == "cont")
                {

                }
                else
                {
                    Console.WriteLine("type retry or cont!!");
                }
            }

            Console.WriteLine("Formatting drive... this will wipe it. Continue?? (y/n)");
            Console.Write(">>");

            
            if(Console.ReadLine() == "n")
            {
                Console.Clear();
                goto Devices;
            }




        }
    }
}
