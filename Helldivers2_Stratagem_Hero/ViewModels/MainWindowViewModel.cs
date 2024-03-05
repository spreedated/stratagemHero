#pragma warning disable CA1822

using CommunityToolkit.Mvvm.ComponentModel;
using neXn.Lib.ViewLogic;
using System.Reflection;
using System.Windows.Controls;

namespace Helldivers2_Stratagem_Hero.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject, IViewManagerWindow
    {
        public string Title
        {
            get
            {
                Assembly a = typeof(MainWindowViewModel).Assembly;
                return $"{a.GetCustomAttribute<AssemblyTitleAttribute>().Title} v{a.GetName().Version}";
            }
        }

        [ObservableProperty]
        private Page currentPage;
    }
}
