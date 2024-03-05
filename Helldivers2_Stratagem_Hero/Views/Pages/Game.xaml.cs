using CommunityToolkit.Mvvm.ComponentModel;
using Helldivers2_Stratagem_Hero.Logic;
using Helldivers2_Stratagem_Hero.Models;
using Helldivers2_Stratagem_Hero.ViewElements;
using Helldivers2_Stratagem_Hero.ViewLogic;
using neXn.Lib.ViewLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Media;
using static Helldivers2_Stratagem_Hero.Logic.Globals;
using static neXn.Lib.Wpf.ViewLogic.HelperFunctions;

namespace Helldivers2_Stratagem_Hero.Views.Pages
{
    [ObservableObject]
    public partial class Game : Page, IImplementKeys, IViewManagerPage
    {
        private readonly Timer gameTimer;
        private readonly List<Stratagem> stratagemList = [];

        private readonly Queue<Stratagem> roundStratagem = [];

        [ObservableProperty]
        private bool isPerfectRound;

        [ObservableProperty]
        private Stratagem currentStratagem;

        [ObservableProperty]
        private int displayScore;

        [ObservableProperty]
        private int displayRound;

        [ObservableProperty]
        private double timerBar;

        private void LoadStratagems()
        {
            this.stratagemList.Clear();
            Assembly a = typeof(Game).Assembly;
            a.GetTypes().Where(x => x.IsSubclassOf(typeof(Stratagem)))
                .ToList()
                .ForEach(x => this.stratagemList.Add((Stratagem)Activator.CreateInstance(x)));
        }

        private void RandomlySelectRoundStratagems()
        {
            this.roundStratagem.Clear();
            Random r = new(BitConverter.ToInt32(Guid.NewGuid().ToByteArray()));

            for (int i = 0; i < (6 + Currentround); i++)
            {
                this.roundStratagem.Enqueue(this.stratagemList[r.Next(0, this.stratagemList.Count)]);
            }
        }

        private void SelectNextStratagem()
        {
            if (this.roundStratagem.Count <= 0)
            {
                this.RoundEnd();
                return;
            }

            this.CurrentStratagem = this.roundStratagem.Dequeue();
        }

        private void UpdateStrataPanel(bool setNew = false)
        {
            if (setNew)
            {
                this.StrataPanel.Children.Clear();

                foreach (Stratagem.StratagemKey k in this.CurrentStratagem.Keys)
                {
                    Arrow a = new()
                    {
                        Direction = k.Direction,
                        IsPressed = k.IsHeld,
                        Margin = new(8, 0, 8, 0),
                        Height = 84,
                        Width = 84
                    };
                    this.StrataPanel.Children.Add(a);
                }

                return;
            }

            int counter = 0;
            foreach (Arrow a in this.StrataPanel.Children.OfType<Arrow>())
            {
                a.IsPressed = this.CurrentStratagem.Keys.ElementAt(counter).IsHeld;
                counter++;
            }
        }

        private void UpdateStratagemPreview()
        {
            this.StratagemPreview.Children.Clear();
            int position = 0;
            foreach (Stratagem s in this.roundStratagem.Take(5))
            {
                Image i = new()
                {
                    Source = (ImageSource)new ByteArrayToImageSourceConverter().Convert(s.Icon, typeof(ImageSource), null, CultureInfo.InvariantCulture),
                    Height = 84,
                    Width = 84
                };
                Grid.SetColumn(i, position);
                this.StratagemPreview.Children.Add(i);
                position++;
            }
        }

        public void NewRoundStart()
        {
            this.gameTimer.Stop();
            this.IsPerfectRound = true;
            this.DisplayScore = Score;
            this.RandomlySelectRoundStratagems();
            this.SelectNextStratagem();
            this.UpdateStrataPanel(true);
            this.UpdateStratagemPreview();
            this.gameTimer.Start();
        }

        private void RoundEnd()
        {
            this.gameTimer.Stop();
            Globals.ViewManager.ChangePage("roundend");
            ((RoundEnd)Globals.ViewManager.GetCurrentPage()).Calculate(this.IsPerfectRound, (int)Math.Floor(this.TimerBar / 10));

            Random rnd = new();
            Globals.AudioManager.PlaySoundEffect(rnd.NextDouble() <= 0.5d ? "round_won" : "round_won_alternative");
        }

        private void UpdateScore(int scoreToAdd)
        {
            Score += scoreToAdd;
            this.DisplayScore = Score;
        }

        public Game()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.LoadStratagems();

            this.gameTimer = new()
            {
                Interval = TimeSpan.FromMilliseconds(20).TotalMilliseconds
            };

            this.gameTimer.Elapsed += (o, e) =>
            {
                ForceUiUpdate(this.Dispatcher);

                this.TimerBar -= 0.7d;

                if (this.TimerBar <= 0d)
                {
                    this.gameTimer.Stop();
                    Globals.AudioManager.PlaySoundEffect("round_lost");
                    Globals.ViewManager.ChangePage("playername");
                }
            };
        }

        public void OnPageViewed()
        {
            this.TimerBar = 1000d;

            this.DisplayScore = Score;
            this.DisplayRound = Currentround;
        }

        public void OnPageLeft()
        {
            this.gameTimer?.Stop();
        }

        public void KeyPressed(Stratagem.StratagemKey.Directions direction)
        {
            Stratagem.StratagemKey k = this.CurrentStratagem.Keys.First(x => !x.IsHeld);

            if (k.Direction != direction)
            {
                this.IsPerfectRound = false;
                this.CurrentStratagem.Reset();
                this.UpdateStrataPanel();
                Globals.AudioManager.PlaySoundEffect("click_fail");

                return;
            }

            k.Set();

            if (this.CurrentStratagem.Keys.All(x => x.IsHeld))
            {
                this.CurrentStratagem.Reset();
                this.TimerBar += 15d;
                this.UpdateScore(this.CurrentStratagem.Score);
                this.SelectNextStratagem();
                Globals.AudioManager.PlaySoundEffect("click_success");
                this.UpdateStrataPanel(true);
                this.UpdateStratagemPreview();

                return;
            }

            this.UpdateStrataPanel();
        }
    }
}
