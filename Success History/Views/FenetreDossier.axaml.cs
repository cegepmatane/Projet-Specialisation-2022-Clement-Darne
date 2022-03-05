using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Success_History.Views
{
    public partial class FenetreDossier : Window
    {
        public FenetreDossier()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
