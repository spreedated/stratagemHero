using Audio;
using Helldivers2_Stratagem_Hero.ViewLogic;
using neXn.Lib.ViewLogic;

namespace Helldivers2_Stratagem_Hero.Logic
{
    public static class Globals
    {
        public static AudioManager AudioManager { get; set; }
        public static ViewManager ViewManager { get; set; }
        public static KeyManager KeyManager { get; set; }
        public static int Score { get; set; }
        public static int Currentround { get; set; } = 1;
        public static string Playername { get; set; }
    }
}
