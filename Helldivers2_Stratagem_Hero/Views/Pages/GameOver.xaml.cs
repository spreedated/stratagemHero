using CommunityToolkit.Mvvm.ComponentModel;
using Helldivers2_Stratagem_Hero.Logic;
using Helldivers2_Stratagem_Hero.Models;
using Helldivers2_Stratagem_Hero.ViewLogic;
using neXn.Lib.ViewLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;

namespace Helldivers2_Stratagem_Hero.Views.Pages
{
    [ObservableObject]
    public partial class GameOver : Page, IViewManagerPage, IImplementKeys
    {
        private readonly Timer displayTimer;
        private bool canBeSkipped = false;

        [ObservableProperty]
        private List<HighscoreDisplay> highscores;

        [ObservableProperty]
        private int displayScore;

        #region Constructor
        public GameOver()
        {
            this.InitializeComponent();
            this.DataContext = this;

            this.displayTimer = new Timer(2500);
            this.displayTimer.Elapsed += (s, e) =>
            {
                this.canBeSkipped = true;
                this.displayTimer.Stop();
            };
        }
        #endregion

        public void OnPageViewed()
        {
            Task.Run(async () =>
            {
                await this.RetrieveHighscoreList(Globals.Score);
            });
            this.DisplayScore = Globals.Score;
            this.displayTimer.Start();

            Globals.Currentround = 1;
            Globals.Score = 0;
        }

        public void OnPageLeft()
        {
            this.displayTimer?.Stop();
        }

        private async Task RetrieveHighscoreList(int score = default)
        {
            Highscore.HighscoreManager h = new();
            await h.Load();

            if (score != default)
            {
                await h.Insert(new()
                {
                    Playername = Globals.Playername,
                    Score = score,
                    Date = DateTime.Now
                });
            }

            List<HighscoreDisplay> hscores = [];

            foreach (Highscore.Models.Highscore hs in await h.Get100())
            {
                hscores.Add(new HighscoreDisplay
                {
                    Postition = hscores.Count + 1,
                    Highscore = hs
                });
            }

            this.Highscores = hscores;
        }

        public void KeyPressed(Stratagem.StratagemKey.Directions direction)
        {
            if (this.canBeSkipped)
            {
                Globals.ViewManager.ChangePage("welcome");
            }
        }

        public class HighscoreDisplay
        {
            public int Postition { get; set; }
            public Highscore.Models.Highscore Highscore { get; set; }
        }
    }
}
