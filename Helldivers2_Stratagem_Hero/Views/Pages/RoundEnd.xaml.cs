#pragma warning disable S1104

using CommunityToolkit.Mvvm.ComponentModel;
using Helldivers2_Stratagem_Hero.Logic;
using neXn.Lib.ViewLogic;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using static Helldivers2_Stratagem_Hero.Logic.Globals;

namespace Helldivers2_Stratagem_Hero.Views.Pages
{
    [ObservableObject]
    public partial class RoundEnd : Page, IDisposable, IViewManagerPage
    {
        private Timer displayTimer;
        private Timer rowVisiblityTimer;
        private int rowVisiblityTimerRuns;

        [ObservableProperty]
        public int displayScore;

        [ObservableProperty]
        public int timebonus;

        [ObservableProperty]
        public int roundbonus;

        [ObservableProperty]
        public int perfectRoundbonus;

        [ObservableProperty]
        public bool isPerfectRound;

        [ObservableProperty]
        public Visibility secondRowVisibility;

        [ObservableProperty]
        public Visibility thirdRowVisibility;

        [ObservableProperty]
        public Visibility fourthRowVisibility;

        private void VisibilityTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.rowVisiblityTimerRuns <= 0)
            {
                this.SecondRowVisibility = Visibility.Visible;
                this.rowVisiblityTimerRuns++;
                return;
            }
            if (this.rowVisiblityTimerRuns == 1)
            {
                this.ThirdRowVisibility = Visibility.Visible;
                this.rowVisiblityTimerRuns++;
                return;
            }
            this.FourthRowVisibility = Visibility.Visible;
            this.rowVisiblityTimer.Stop();
        }

        private void DisplayTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Globals.ViewManager.ChangePage("roundbegin");
            this.displayTimer.Stop();
        }

        private void CalculateScore()
        {
            this.Roundbonus = (Currentround * 25) + 75;
            if (this.IsPerfectRound)
            {
                this.PerfectRoundbonus = 100;
            }

            Score += this.Roundbonus + this.PerfectRoundbonus + this.Timebonus;
            Currentround++;

            this.DisplayScore = Score;
        }

        #region Constructor
        public RoundEnd()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        public void OnPageViewed()
        {
            this.SecondRowVisibility = Visibility.Hidden;
            this.ThirdRowVisibility = Visibility.Hidden;
            this.FourthRowVisibility = Visibility.Hidden;

            this.rowVisiblityTimer = new()
            {
                Interval = TimeSpan.FromSeconds(0.5d).TotalMilliseconds
            };
            this.rowVisiblityTimer.Elapsed += this.VisibilityTimer_Elapsed;
            this.rowVisiblityTimer.Start();

            this.displayTimer = new()
            {
                Interval = TimeSpan.FromSeconds(5d).TotalMilliseconds
            };
            this.displayTimer.Elapsed += this.DisplayTimer_Elapsed;
            this.displayTimer.Start();
        }

        public void OnPageLeft()
        {
            this.rowVisiblityTimer?.Stop();
            this.displayTimer?.Stop();
            this.rowVisiblityTimerRuns = 0;
        }

        public void Calculate(bool isPerfectRound, int timebonus)
        {
            this.IsPerfectRound = isPerfectRound;
            this.Timebonus = timebonus;

            this.CalculateScore();
        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.rowVisiblityTimer?.Dispose();
                this.displayTimer?.Dispose();
                this.Dispose(disposing: false);
            }
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
