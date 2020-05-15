using System;
using System.Collections.Generic;
using System.Text;

namespace ReactionTimer
{
    class CustomTester
    {
        private static IController controller;
        private static IGui gui;
        private static string displayText;
        private static int randomNumber;
        private static int passed = 0;

        public void Init()
        {
            Console.WriteLine("\n\n");
            Tester();
            Console.WriteLine("\n=====================================\nSummary: {0} tests passed out of 56", passed);
            Console.ReadKey();
        }
        private void Tester()
        {
            //Construct a ReactionController
            controller = new SimpleReactionController();
            gui = new DummyGui();

            //Connect them to each other
            gui.Connect(controller);
            controller.Connect(gui, new RndGenerator());

            //Reset the components()
            gui.Init();

            //Idle state
            DoReset(1, controller, "Start your game!");

            //Insert a coin to move to Ready state
            DoInsertCoin(2, controller, "Press Go/Stop");

            //Press Go/Stop to move to wait state
            DoGoStop(3, controller, "Wait a bit");

            //Idle -> Ignore
            DoReset(4, controller, "Start your game!");
            DoTicks(5, controller, 10000, "Start your game!");

            //Idle -> Ready -> Ignore
            DoReset(6, controller, "Start your game!");
            DoInsertCoin(7, controller, "Press Go/Stop");
            DoTicks(8, controller, 10000, "Start your game!");

            //Idle -> Ready -> Wait -> abort
            DoReset(9, controller, "Start your game!");
            DoInsertCoin(10, controller, "Press Go/Stop");
            DoGoStop(11, controller, "Wait a bit");
            DoGoStop(12, controller, "Start your game!");

            //Idle -> Ready -> Wait -> Display (Ignore for 650 ticks) -> Ready (Ignore for 650 ticks)
            DoReset(13, controller, "Start your game!");
            DoInsertCoin(14, controller, "Press Go/Stop");
            DoGoStop(15, controller, "Wait a bit");
            DoTicks(16, controller, 650, "Press Go/Stop");

            //Idle -> Ready -> Wait -> Display -> Ignore for 650 + 1000 ticks
            DoReset(17, controller, "Start your game!");
            DoInsertCoin(18, controller, "Press Go/Stop");
            DoGoStop(19, controller, "Wait a bit");
            DoTicks(20, controller, 650, "Press Go/Stop");
            DoTicks(21, controller, 1000, "Start your game!");

            //Idle -> Ready -> Wait -> Display -> Ready
            DoReset(22, controller, "Start your game!");
            DoInsertCoin(23, controller, "Press Go/Stop");
            DoGoStop(24, controller, "Wait a bit");
            DoTicks(controller, 300);
            DoGoStop(25, controller, "Press Go/Stop");

            //Idle -> Ready -> Wait -> Display(Turn 1) -> Ready -> Wait -> Display(Turn 2) -> Ready -> Wait -> Display(Turn 3) (Press Go/Stop) -> Idle 
            DoReset(26, controller, "Start your game!");        //-> Idle
            DoInsertCoin(27, controller, "Press Go/Stop");      //-> Ready
            DoGoStop(28, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 1
            DoGoStop(29, controller, "Press Go/Stop");          //-> Ready
            DoGoStop(30, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 2
            DoGoStop(31, controller, "Press Go/Stop");          //-> Ready
            DoGoStop(32, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 3
            DoGoStop(33, controller, "Start your game!");       //-> Idle

            //Idle -> Ready -> Wait -> Display(Turn 1) -> Ready -> Wait -> Display(Turn 2) -> Ready -> Wait -> Display(Turn 3) (Time out) -> Idle 
            DoReset(34, controller, "Start your game!");        //-> Idle
            DoInsertCoin(35, controller, "Press Go/Stop");      //-> Ready
            DoGoStop(36, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 1
            DoGoStop(37, controller, "Press Go/Stop");          //-> Ready
            DoGoStop(38, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 2
            DoGoStop(39, controller, "Press Go/Stop");          //-> Ready
            DoGoStop(40, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 3
            DoTicks(41, controller, 1001, "Start your game!");  //-> Idle

            //Idle -> Ready (Insert Coin +3 turns) -> Wait -> Display(Turn 1) -> ... -> (Turn 6) -> ignore
            DoReset(42, controller, "Start your game!");        //-> Idle
            DoInsertCoin(43, controller, "Press Go/Stop");      //-> Ready
            DoInsertCoin(44, controller, "Press Go/Stop");      // +3 turns!
            DoGoStop(45, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 1
            DoGoStop(46, controller, "Press Go/Stop");          //-> Ready
            DoGoStop(47, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 2
            DoGoStop(48, controller, "Press Go/Stop");          //-> Ready
            DoGoStop(49, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 3
            DoGoStop(50, controller, "Press Go/Stop");          //-> Ready
            DoGoStop(51, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 4
            DoGoStop(52, controller, "Press Go/Stop");          //-> Ready
            DoGoStop(53, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 5
            DoGoStop(54, controller, "Press Go/Stop");          //-> Ready
            DoGoStop(55, controller, "Wait a bit");             //-> Wait
            DoTicks(controller, 300);                           //-> Display 6
            DoTicks(56, controller, 1050, "Start your game!");  //-> Idle



        }
        private static void DoReset(int ch, IController controller, string msg)
        {
            try
            {
                controller.Init();
                GetMessage(ch, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", ch, msg, exception.Message);
            }
        }

        private static void DoGoStop(int ch, IController controller, string msg)
        {
            try
            {
                controller.GoStopPressed();
                GetMessage(ch, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", ch, msg, exception.Message);
            }
        }

        private static void DoInsertCoin(int ch, IController controller, string msg)
        {
            try
            {
                controller.CoinInserted();
                GetMessage(ch, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", ch, msg, exception.Message);
            }
        }

        private static void DoTicks(int ch, IController controller, int n, string msg)
        {
            try
            {
                for (int t = 0; t < n; t++) controller.Tick();
                GetMessage(ch, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", ch, msg, exception.Message);
            }
        }

        private static void DoTicks(IController controller, int n)
        {
            for (int t = 0; t < n; t++)
                controller.Tick();
        }

        private static void GetMessage(int ch, string msg)
        {
            if (msg.ToLower() == displayText.ToLower())
            {
                Console.WriteLine("test {0}: passed successfully", ch);
                passed++;
            }
            else
                Console.WriteLine("test {0}: failed with message ( expected {1} | received {2})", ch, msg, displayText);
        }
        private class DummyGui : IGui
        {

            private IController controller;

            public void Connect(IController controller)
            {
                this.controller = controller;
            }

            public void Init()
            {
                displayText = "Start your game!";
            }

            public void SetDisplay(string msg)
            {
                displayText = msg;
            }
        }

        private class RndGenerator : IRandom
        {
            public int GetRandom(int from, int to)
            {
                return randomNumber;
            }
        }
    }
}
