using Audio;
using Helldivers2_Stratagem_Hero.Logic;
using System.Threading.Tasks;
using System.Windows;

namespace Helldivers2_Stratagem_Hero
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Globals.KeyManager = new();
            Globals.ViewManager = new();
            Globals.AudioManager = new();

            Task.Run(AudioBanks.LoadAudioBanks);
        }
    }
}
