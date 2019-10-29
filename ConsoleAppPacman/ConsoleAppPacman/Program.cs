using System;

namespace ConsoleAppPacman
{
    class Program
    {
        static void Main(string[] args)
        {
            Pacman pacman = new Pacman();

            pacman.State = PacmanState.Spawning; //keep the same
            pacman.State = PacmanState.Still;

            Console.ReadKey();
        }
    }
}
