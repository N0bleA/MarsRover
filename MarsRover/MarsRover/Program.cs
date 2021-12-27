using MarsRover_Core.Interfaces;
using MarsRover_Core.Services;
using MarsRover_Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace MarsRover
{
    class Program
    {
        static void Main()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IDeployRover, DeployRover>()
                .AddSingleton<ICreatePlateau, CreatePlateau>()
                .AddSingleton<IInputManager, InputManager>()
                .AddSingleton<ICommandParser, CommandParser>()
                .AddSingleton<IPlateauCommandExecuter, PlateauCommandExecuter>()
                .AddSingleton<IDeployRoverCommandExecuter, DeployRoverCommandExecuter>()
                .AddSingleton<IInstructionExecuter, InstructionExecuter>()
                .BuildServiceProvider();


            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            var InputManagerService = serviceProvider.GetService<IInputManager>();
            InputManagerService.SendCommand("5 5");
            InputManagerService.SendCommand("1 2 N");
            InputManagerService.SendCommand("LMLMLMLMM");
            InputManagerService.SendCommand("3 3 E");
            InputManagerService.SendCommand("MMRMMRMRRM");

            //stopwatch.Stop();

            //Console.WriteLine("Ticks: " + stopwatch.ElapsedTicks +
            //    " mS: " + stopwatch.ElapsedMilliseconds);


        }
    }
}
