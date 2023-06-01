using Microsoft.UI.Xaml;
using Uno.Toolkit.UI;
using Windows.UI.ViewManagement;

namespace Clients.UnoApp.Presentation
{
    public sealed partial class Shell : UserControl, IContentControlProvider
    {
        public Shell()
        {
            Configuration();
            this.InitializeComponent();
        }

        public ContentControl ContentControl => Splash;

        private void Configuration()
        {
            this.MinHeight = 763;
            this.MinWidth = 1200;
        }
        
    }
}