using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Success_History.ViewModels;
using Success_History.Views;

namespace Success_History
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new FenetreDossier
                {
                    DataContext = new FenetreDossierViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
