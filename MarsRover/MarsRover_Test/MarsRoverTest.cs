using MarsRover_Core.Interfaces;
using MarsRover_Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace MarsRover_Test
{

    public class MarsRoverTest
    {
        [Fact]
        public void IsOutputCorrect()
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


            var InputManagerService = serviceProvider.GetService<IInputManager>();
            InputManagerService.SendCommand("5 5");
            InputManagerService.SendCommand("1 2 N");
            InputManagerService.SendCommand("LMLMLMLMM");
            InputManagerService.SendCommand("3 3 E");
            InputManagerService.SendCommand("MMRMMRMRRM");


            IDeployRover roverDeployManager = serviceProvider.GetService<IDeployRover>();


            Assert.NotNull(roverDeployManager.RoverList);
            Assert.Equal("1 3 N", roverDeployManager.RoverList[0].ToString());
            Assert.Equal("5 1 E", roverDeployManager.RoverList[1].ToString());
            Assert.Equal(5, roverDeployManager.Plateau.Plateau.Height);
            Assert.Equal(5, roverDeployManager.Plateau.Plateau.Width);
        }

        [Fact]
        public void IsRoverDeployable()
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


            var InputManagerService = serviceProvider.GetService<IInputManager>();
            InputManagerService.SendCommand("5 5");

            Assert.Throws<Exception>(() => InputManagerService.SendCommand("1 7 N"));
         
        }
        [Fact]
        public void IsValidInput()
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

            var InputManagerService = serviceProvider.GetService<IInputManager>();


            Assert.Throws<Exception>(() => InputManagerService.SendCommand("5 B"));
            Assert.Throws<Exception>(() => InputManagerService.SendCommand("1 7 A"));

        }





    }
}
