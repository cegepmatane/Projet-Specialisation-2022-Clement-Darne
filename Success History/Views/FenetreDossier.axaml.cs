using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Layout;


namespace Success_History.Views
{
    public partial class FenetreDossier : Window
    {
        public FenetreDossier()
        {
            InitializeComponent();

            // Sauvegarder : CTRL + S
            var sauvegarderMenuItem = this.FindControl<MenuItem>("SauvegarderMenuItem");
            HotKeyManager.SetHotKey(sauvegarderMenuItem, new KeyGesture(Key.S, KeyModifiers.Control));

            // Sauvegarder sous : CTRL + SHIFT + S
            var sauvegarderSousMenuItem = this.FindControl<MenuItem>("SauvegarderSousMenuItem");
            HotKeyManager.SetHotKey(sauvegarderSousMenuItem, new KeyGesture(Key.S, KeyModifiers.Control | KeyModifiers.Shift));

            // Ouvrir : CTRL + O
            var ouvrirMenuItem = this.FindControl<MenuItem>("OuvrirMenuItem");
            HotKeyManager.SetHotKey(sauvegarderMenuItem, new KeyGesture(Key.O, KeyModifiers.Control));
            
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        public async void SauvegarderSous(string initialFileName = "notes.shist")
        {
            Window? parent = (Window?)VisualRoot;
            if (parent == null)
                return;

            string? filePath = await Dialogs.FichierDialogue.Get().SauvegarderDossier(parent, initialFileName);
            System.Console.WriteLine(filePath);

            ((ViewModels.FenetreDossierViewModel?)this.DataContext)?.SauvegarderDossier(filePath);
        }
    }
}
