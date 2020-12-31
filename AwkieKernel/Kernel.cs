using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace AwkieKernel
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Boot Success!!");
        }

        protected override void Run()
        {
            Console.WriteLine("Welcome to AwkieOS!");
        Top:
            Console.Write(">>");
            var input = Console.ReadLine();
            switch (input)
            {
                case "help":
                    Console.WriteLine("I'm here to help! Here are some available commands:");
                    break;
                case "gui":

                    break;
                default:
                    Console.WriteLine("invalid or mistyped command");
                    break;
            }
                
            goto Top;
        }
    }
}
