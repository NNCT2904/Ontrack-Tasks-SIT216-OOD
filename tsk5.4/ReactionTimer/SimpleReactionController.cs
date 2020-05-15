using System;
using System.Collections.Generic;
using System.Text;

namespace ReactionTimer
{
    public interface IState
    {
        //Called whenever a coin is inserted into the machine
        //Coin Inserted => + 3 to available turn
        void CoinInserted();

        //Called whenever the go/stop button is pressed
        void GoStopPressed();

        //Called to deliver a TICK to the controller
        void Tick();
    }

    public class SimpleReactionController : IController
    {
        IState CurrentState { get; set; }
        public int CountTick { get; set; }
        public int CountTotalTick { get; set; }
        public int TurnAvailable { get; set; }
        public int CountTotalTurn { get; set; }

        public IGui gui { get; set; }
        public IRandom random { get; set; }


        public void Connect(IGui gui, IRandom rng)
        {
            this.gui = gui;
            this.random = rng;
            this.gui.Connect(this);
            Init();
        }

        public void CoinInserted()
        {
            this.CurrentState.CoinInserted();
        }

        public void GoStopPressed()
        {
            this.CurrentState.GoStopPressed();
        }

        public void Init()
        {
            CurrentState = new IdleState(this);
        }

        public void Tick()
        {
            CurrentState.Tick();
        }

        public void ChangeState(IState state)
        {
            this.CurrentState = state;
        }
    }

    //Game over = Idle state, Start game = Idle state
    public class IdleState : IState
    {
        private SimpleReactionController _controller;

        public IdleState(SimpleReactionController controller)
        {
            this._controller = controller;
            this._controller.gui.Init();
            //Game Over or Start a game, set turn to 1
            this._controller.TurnAvailable = 3;
            this._controller.CountTotalTurn = 3;
        }
        public void CoinInserted()
        {
            this._controller.ChangeState(new ReadyState(this._controller));
        }

        public void GoStopPressed()
        {
            this._controller.ChangeState(new IdleState(this._controller));
        }

        public void Tick()
        {
            
        }
    }

    public class ReadyState : IState
    {
        private SimpleReactionController _controller;
        private int tickOut;


        public ReadyState(SimpleReactionController controller)
        {
            this._controller = controller;
            this._controller.gui.SetDisplay("Press Go/Stop");
        }

        public void CoinInserted()
        {
            this._controller.TurnAvailable += 3;
            this._controller.CountTotalTurn += 3;
        }

        public void GoStopPressed()
        {
            this._controller.ChangeState(new WaitState(this._controller));
        }


        public void Tick()
        {
            // 1000 Tick = 10 sec
            tickOut++;
            if (tickOut >= 1000)
            {
                this._controller.ChangeState(new IdleState(this._controller));
            }
        }
    }

    public class WaitState : IState
    {

        public SimpleReactionController _controller;
        int timerCounter;

        public WaitState(SimpleReactionController controller)
        {
            this._controller = controller;
            this._controller.gui.SetDisplay("Wait a bit");
            this._controller.CountTick = this._controller.random.GetRandom(150, 200);
        }
        public void CoinInserted()
        {
            this._controller.TurnAvailable += 3;
            this._controller.CountTotalTurn += 3;
        }

        public void GoStopPressed()
        {
            this._controller.ChangeState(new IdleState(this._controller));
        }

        public void Tick()
        {
            timerCounter += 1;
            if (timerCounter >= this._controller.CountTick)
            {
                this._controller.ChangeState(new DisplayState(this._controller));
            }
        }
    }

    public class DisplayState : IState
    {
        public SimpleReactionController _controller;

        private int tickOut = 0;

        public DisplayState(SimpleReactionController controller)
        {
            this._controller = controller;
            //At the last turn, display another messge
            if (this._controller.TurnAvailable <= 1)
            {
                this._controller.gui.SetDisplay($"Average ticks: {Convert.ToString(this._controller.CountTotalTick / this._controller.CountTotalTurn)}");
            }
            else
            {
                this._controller.CountTotalTick += this._controller.CountTick;
                this._controller.gui.SetDisplay($"{Convert.ToString(this._controller.CountTick)} ticks has passed");
            }
        }
        public void CoinInserted()
        {
            this._controller.TurnAvailable += 3;
            this._controller.CountTotalTurn += 3;
        }

        public void GoStopPressed()
        {
            if (this._controller.TurnAvailable <= 1)
            {
                this._controller.ChangeState(new IdleState(this._controller));

            }
            else
            {
                this._controller.TurnAvailable -= 1;
                this._controller.ChangeState(new ReadyState(this._controller));
            }
        }

        public void Tick()
        {
            // 1 Tick = 10 ms => 300 ticks = 3 secs
            // Change state when timeout
            // If this is the last turn, set to IDLE
            // Else get to READY, and +1 to Turn
            tickOut++;
            if (this.tickOut >= 300)
            {
                if (this._controller.TurnAvailable <= 1)
                {
                    this._controller.ChangeState(new IdleState(this._controller));
                }
                else
                {
                    this._controller.TurnAvailable -= 1;
                    this._controller.ChangeState(new ReadyState(this._controller));
                }
            }
        }
    }
}
