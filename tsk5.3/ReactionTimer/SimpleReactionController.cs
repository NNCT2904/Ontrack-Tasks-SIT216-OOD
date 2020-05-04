using System;
using System.Collections.Generic;
using System.Text;

namespace ReactionTimer
{
    public class SimpleReactionController : IController
    {
        IController state;
        SimpleReactionMachine machine = new SimpleReactionMachine();
        public double count;

        public IGui gui { get; set; }
        public IRandom random { get; set; }

        public SimpleReactionController()
        {
            Init();
        }

        public void Connect(IGui gui, IRandom rng)
        {
            this.gui = gui;
            this.random = rng;
        }

        public void CoinInserted()
        {
            this.state.CoinInserted();
        }

        public void GoStopPressed()
        {
            this.state.GoStopPressed();
        }

        public void Init()
        {
            ChangeState(new IdleState(this));
        }

        public void Tick()
        {
            
        }

        public void ChangeState(IController state)
        {
            this.state = state;
        }
    }


    public class IdleState : IController
    {
        private SimpleReactionController _controller;

        public IdleState(SimpleReactionController controller)
        {           
            this._controller = controller;
        }
        public void CoinInserted()
        {
            this._controller.ChangeState(new ReadyState(this._controller));
        }

        public void Connect(IGui gui, IRandom rng)
        {
            this._controller.gui = gui;
            this._controller.random = rng;
        }

        public void GoStopPressed()
        {
            this._controller.ChangeState(new IdleState(this._controller));
        }

        public void Init()
        {
            this._controller.Init();
        }

        public void Tick()
        {
            this._controller.Tick();
        }
    }

    public class ReadyState : IController
    {
        private SimpleReactionController _controller;

        public ReadyState(SimpleReactionController controller)
        {
            this._controller = controller;
            this._controller.gui.SetDisplay("Ready State, press go/stop");
        }

        public void CoinInserted()
        {
            this._controller.ChangeState(new ReadyState(this._controller));
        }

        public void Connect(IGui gui, IRandom rng)
        {
            this._controller.gui = gui;
            this._controller.random = rng;
        }

        public void GoStopPressed()
        {
            this._controller.ChangeState(new WaitState(this._controller));
        }

        public void Init()
        {
            this._controller.Init();
        }

        public void Tick()
        {
            this._controller.Tick();
        }
    }

    public class WaitState : IController
    {

        public SimpleReactionController _controller;

        public WaitState(SimpleReactionController controller)
        {
            this._controller = controller;
            this._controller.gui.SetDisplay("Wait a bit");
        }
        public void CoinInserted()
        {
            this._controller.ChangeState(new WaitState(this._controller));
        }

        public void Connect(IGui gui, IRandom rng)
        {
            this._controller.gui = gui;
            this._controller.random = rng;
        }

        public void GoStopPressed()
        {
            this._controller.ChangeState(new SimpleReactionController());
        }

        public void Init()
        {
            this._controller.Init();
        }

        public void Tick()
        {
            _controller.count += 1;
            _controller.gui.SetDisplay(_controller.count.ToString());
        }
    }
}
