using Helldivers2_Stratagem_Hero.Logic;
using System.Windows;

namespace Helldivers2_Stratagem_Hero.Views
{
    public partial class DebugWindow : Window
    {
        public DebugWindow()
        {
            this.InitializeComponent();
            this.Top = 0d;
            this.Left = 0d;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Globals.ViewManager.ChangePage("welcome");
        }

        private void ButtonGameOver_Click(object sender, RoutedEventArgs e)
        {
            Globals.ViewManager.ChangePage("gameover");
        }

        private void RoundEnd_Click(object sender, RoutedEventArgs e)
        {
            Globals.ViewManager.ChangePage("roundend");
        }

        private void ButtonPlayername_Click(object sender, RoutedEventArgs e)
        {
            Globals.ViewManager.ChangePage("playername");
        }
    }
}
