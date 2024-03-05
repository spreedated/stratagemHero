using Helldivers2_Stratagem_Hero.Logic;
using Helldivers2_Stratagem_Hero.Models;
using Helldivers2_Stratagem_Hero.Views.Pages;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using static Helldivers2_Stratagem_Hero.Models.Stratagem.StratagemKey;

namespace Helldivers2_Stratagem_Hero.ViewLogic
{
    public class KeyManager
    {
        private readonly Dictionary<Key, Action> registeredKeys = [];
        private readonly HashSet<Key> keysDown = [];

        /// <summary>
        /// Fires the event only on keydown & keyup<br/>
        /// Set to false for a responsive feel
        /// </summary>
        public bool NeedFullPress { get; set; }

        public void RegisterKeyHandler(Key key, Action action)
        {
            if (this.registeredKeys.ContainsKey(key) && action != null)
            {
                return;
            }

            this.registeredKeys.Add(key, action);
        }

        public static void RegisterKeys()
        {
            Globals.KeyManager.RegisterKeyHandler(Key.Up, KeyPressed_Up);
            Globals.KeyManager.RegisterKeyHandler(Key.Down, KeyPressed_Down);
            Globals.KeyManager.RegisterKeyHandler(Key.Left, KeyPressed_Left);
            Globals.KeyManager.RegisterKeyHandler(Key.Right, KeyPressed_Right);
            Globals.KeyManager.RegisterKeyHandler(Key.W, KeyPressed_Up);
            Globals.KeyManager.RegisterKeyHandler(Key.S, KeyPressed_Down);
            Globals.KeyManager.RegisterKeyHandler(Key.A, KeyPressed_Left);
            Globals.KeyManager.RegisterKeyHandler(Key.D, KeyPressed_Right);
            Globals.KeyManager.RegisterKeyHandler(Key.Enter, KeyPressed_Enter);
        }

        private static void ForwardToWelcomePage()
        {
            if (Globals.ViewManager.PageTitle.Equals("welcome", StringComparison.InvariantCultureIgnoreCase))
            {
                Globals.ViewManager.ChangePage("roundbegin");
            }
        }

        private static bool ForwardToGamePage(Models.Stratagem.StratagemKey.Directions direction)
        {
            if (Globals.ViewManager.PageTitle.Equals("game", StringComparison.InvariantCultureIgnoreCase))
            {
                ((IImplementKeys)Globals.ViewManager.GetCurrentPage()).KeyPressed(direction);
                return true;
            }
            return false;
        }

        private static bool ForwardToGameOverPage()
        {
            if (Globals.ViewManager.PageTitle.Equals("gameover", StringComparison.InvariantCultureIgnoreCase))
            {
                ((IImplementKeys)Globals.ViewManager.GetCurrentPage()).KeyPressed(Directions.Up);
                return true;
            }
            return false;
        }

        public static void KeyPressed_Up()
        {
            if (ForwardToGamePage(Stratagem.StratagemKey.Directions.Up))
            {
                return;
            }
            if (ForwardToGameOverPage())
            {
                return;
            }
            ForwardToWelcomePage();
        }

        public static void KeyPressed_Down()
        {
            if (ForwardToGamePage(Stratagem.StratagemKey.Directions.Down))
            {
                return;
            }
            if (ForwardToGameOverPage())
            {
                return;
            }
            ForwardToWelcomePage();
        }
        public static void KeyPressed_Left()
        {
            if (ForwardToGamePage(Stratagem.StratagemKey.Directions.Left))
            {
                return;
            }
            if (ForwardToGameOverPage())
            {
                return;
            }
            ForwardToWelcomePage();
        }

        public static void KeyPressed_Right()
        {
            if (ForwardToGamePage(Stratagem.StratagemKey.Directions.Right))
            {
                return;
            }
            if (ForwardToGameOverPage())
            {
                return;
            }
            ForwardToWelcomePage();
        }

        public static void KeyPressed_Enter()
        {
            if (Globals.ViewManager.PageTitle.Equals("playername", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(((Playername)Globals.ViewManager.GetCurrentPage()).PlayernameInput))
            {
                Globals.ViewManager.ChangePage("gameover");
            }
        }

        public void KeyDown(KeyEventArgs e)
        {
            if (this.registeredKeys.TryGetValue(e.Key, out Action value) && !this.keysDown.Contains(e.Key))
            {
                this.keysDown.Add(e.Key);

                if (!this.NeedFullPress)
                {
                    value();
                }
            }

            Random rnd = new();
            double rs = rnd.NextDouble();

            Globals.AudioManager.PlaySoundEffect(rs <= 0.5d ? "click1" : "click2");
        }

        public void KeyUp(KeyEventArgs e)
        {
            if (this.NeedFullPress && this.keysDown.Contains(e.Key))
            {
                this.registeredKeys[e.Key]();
            }

            if (this.keysDown.Contains(e.Key))
            {
                this.keysDown.Remove(e.Key);
            }
        }
    }
}
