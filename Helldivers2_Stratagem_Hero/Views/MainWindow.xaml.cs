using Helldivers2_Stratagem_Hero.Logic;
using System.Windows;
using System.Windows.Input;

namespace Helldivers2_Stratagem_Hero.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Globals.ViewManager.PreloadPages();
            Globals.ViewManager.SetMainWindow(this);
            Globals.ViewManager.ChangePage("welcome");
            ViewLogic.KeyManager.RegisterKeys();
#if DEBUG
            DebugWindow debug = new();
            debug.Show();
#endif
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Globals.KeyManager.KeyDown(e);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            Globals.KeyManager.KeyUp(e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Globals.AudioManager.EffectVolume = 1f;
        }
    }
}