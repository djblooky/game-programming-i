using System;

namespace ConsoleAppPacman
{
    public enum PacmanState { Spawning, Still, Chomping, SuperPacMan }

    class Pacman
    {
        protected PacmanState _state; //private instance data member for this pacman

        public PacmanState State
        {
            get { return _state; }
            set {
                if(_state != value)
                {
                    this.Log(string.Format("{0} was {1} now {2}", this.ToString(),value,value));

                    _state = value;
                }
      
            }
        }

        public Pacman()
        {
            this._state = PacmanState.Spawning;
        }

        public virtual void Log (string s)
        {
            Console.WriteLine(s);
        }

    }
}
