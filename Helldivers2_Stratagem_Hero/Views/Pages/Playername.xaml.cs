using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helldivers2_Stratagem_Hero.Logic;
using neXn.Lib.ViewLogic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Helldivers2_Stratagem_Hero.Views.Pages
{
    [ObservableObject]
    public partial class Playername : Page, IViewManagerPage
    {
        [ObservableProperty]
        private string playernameInput;

        [ObservableProperty]
        private int score;

        [RelayCommand]
        private async Task Enter()
        {
            Globals.ViewManager.ChangePage("gameover");

            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task Discard()
        {
            Globals.Currentround = 1;
            Globals.Score = 0;
            Globals.ViewManager.ChangePage("welcome");

            await Task.CompletedTask;
        }

        partial void OnPlayernameInputChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Globals.Playername = value;
            }
        }

        #region Constructor
        public Playername()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        public void OnPageViewed()
        {
            this.PlayernameInput = "";
            this.Score = Globals.Score;
        }

        public void OnPageLeft()
        {
        }
    }
}
