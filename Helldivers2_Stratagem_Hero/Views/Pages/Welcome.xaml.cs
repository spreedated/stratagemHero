using neXn.Lib.ViewLogic;
using System.Windows.Controls;

namespace Helldivers2_Stratagem_Hero.Views.Pages
{
    public partial class Welcome : Page, IViewManagerPage
    {
        #region Constructor
        public Welcome()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        public void OnPageViewed()
        {

        }

        public void OnPageLeft()
        {

        }
    }
}
