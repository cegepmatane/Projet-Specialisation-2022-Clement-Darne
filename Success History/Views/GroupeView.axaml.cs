using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Success_History.Views
{
    public partial class GroupeView : UserControl
    {
        public GroupeView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
