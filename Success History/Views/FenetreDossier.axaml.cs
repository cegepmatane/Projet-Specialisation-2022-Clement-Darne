using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Layout;
using System;

namespace Success_History.Views
{
    public partial class FenetreDossier : Window
    {
        public FenetreDossier()
        {
            InitializeComponent();

            // Nouveau : CTRL + N
            var nouveauMenuItem = this.FindControl<MenuItem>("NouveauMenuItem");
            HotKeyManager.SetHotKey(nouveauMenuItem, new KeyGesture(Key.N, KeyModifiers.Control));

            // Sauvegarder : CTRL + S
            var sauvegarderMenuItem = this.FindControl<MenuItem>("SauvegarderMenuItem");
            HotKeyManager.SetHotKey(sauvegarderMenuItem, new KeyGesture(Key.S, KeyModifiers.Control));

            // Sauvegarder sous : CTRL + SHIFT + S
            var sauvegarderSousMenuItem = this.FindControl<MenuItem>("SauvegarderSousMenuItem");
            HotKeyManager.SetHotKey(sauvegarderSousMenuItem, new KeyGesture(Key.S, KeyModifiers.Control | KeyModifiers.Shift));

            // Ouvrir : CTRL + O
            var ouvrirMenuItem = this.FindControl<MenuItem>("OuvrirMenuItem");
            HotKeyManager.SetHotKey(ouvrirMenuItem, new KeyGesture(Key.O, KeyModifiers.Control));
            
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        public async void Nouveau()
        {
            var window = new FenetreNouveauDossier();
            var dossier = await window.ShowDialog<Models.Dossier?>((Window?)VisualRoot);

            if (dossier != null)
                ((ViewModels.FenetreDossierViewModel?)DataContext)?.NouveauDossier(dossier);
        }


        public async void SauvegarderSous(string? initialFileName = null)
        {
            if (initialFileName == null)
                initialFileName = "notes.shist";

            Console.Out.WriteLine(initialFileName);

            Window? parent = (Window?)VisualRoot;
            if (parent == null)
                return;

            string? filePath = await Dialogs.FichierDialogue.Get().SauvegarderDossier(parent, initialFileName);
            if (filePath == null)
                return;

            ((ViewModels.FenetreDossierViewModel?)DataContext)?.SauvegarderDossier(filePath);
        }

        public async void Ouvrir()
        {
            Window? parent = (Window?)VisualRoot;
            if (parent == null)
                return;

            string? filePath = await Dialogs.FichierDialogue.Get().OuvrirDossier(parent);
            if (filePath == null)
                return;

            ((ViewModels.FenetreDossierViewModel?)DataContext)?.OuvrirDossier(filePath);
        }
    }
}
