using System;
using System.Collections.Generic;
using System.Text;

namespace ReactionTimer
{
    public interface IState
    {
        //Called whenever a coin is inserted into the machine
        void CoinInserted();

        //Called whenever the go/stop button is pressed
        void GoStopPressed();

        //Called to deliver a TICK to the controller
        void Tick();
    }

    public class SimpleReactionController : IController
    {
        IState CurrentState { get; set; }
        public int count { get; set; }

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


    public class IdleState : IState
    {
        private SimpleReactionController _controller;

        public IdleState(SimpleReactionController controller)
        {           
            this._controller = controller;
            this._controller.gui.Init();
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

        public ReadyState(SimpleReactionController controller)
        {
            this._controller = controller;
            this._controller.gui.SetDisplay("Press go/stop");
        }

        public void CoinInserted()
        {
            this._controller.ChangeState(new ReadyState(this._controller));
        }

        public void GoStopPressed()
        {
            this._controller.ChangeState(new WaitState(this._controller));
        }


        public void Tick()
        {
             
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
            this._controller.count = this._controller.random.GetRandom(150, 200);
        }
        public void CoinInserted()
        {
            this._controller.ChangeState(new DisplayState(this._controller));

        }

        public void GoStopPressed()
        {
            this._controller.ChangeState(new IdleState(this._controller));
        }

        public void Tick()
        {
            timerCounter += 1;
            if (timerCounter >= this._controller.count)
            {
                this._controller.ChangeState(new DisplayState(this._controller));
            }
        }
    }

    public class DisplayState : IState
    {
        public SimpleReactionController _controller;

        public DisplayState(SimpleReactionController controller)
        {
            this._controller = controller;
            this._controller.gui.SetDisplay(Convert.ToString(this._controller.count));
        }
        public void CoinInserted()
        {
            
        }

        public void GoStopPressed()
        {
            this._controller.ChangeState(new IdleState(this._controller));
        }

        public void Tick()
        {
            
        }
    }
}
