using CommunityToolkit.Mvvm.ComponentModel;
using Helldivers2_Stratagem_Hero.Logic;
using neXn.Lib.ViewLogic;
using System;
using System.Diagnostics;
using System.Timers;
using System.Windows.Controls;
using static Helldivers2_Stratagem_Hero.Logic.Globals;

namespace Helldivers2_Stratagem_Hero.Views.Pages
{
    [ObservableObject]
    public partial class RoundBegin : Page, IDisposable, IViewManagerPage
    {
        private Timer getReadyTimer;
        public string ContentTitle { get; } = "get ready";

        [ObservableProperty]
        private int displayRound;

        private void GetReadyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Debug.Print("Round begin!");
            this.getReadyTimer.Stop();
            Globals.ViewManager.ChangePage("game");
            Globals.ViewManager.GetMainWindow().Dispatcher.Invoke(() =>
            {
                ((Game)Globals.ViewManager.GetCurrentPage()).NewRoundStart();
            });
        }

        #region Constructor
        public RoundBegin()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        public void OnPageViewed()
        {
            this.getReadyTimer = new()
            {
                Interval = TimeSpan.FromSeconds(3).TotalMilliseconds
            };
            this.getReadyTimer.Elapsed += this.GetReadyTimer_Elapsed;
            this.getReadyTimer.Start();

            this.DisplayRound = Currentround;
        }

        public void OnPageLeft()
        {
            this.getReadyTimer?.Dispose();
        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.getReadyTimer?.Dispose();
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
