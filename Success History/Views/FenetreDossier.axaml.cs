using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Layout;
using System;
using System.Collections.ObjectModel;

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
            var groupe = await window.ShowDialog<Models.Groupe?>((Window?)VisualRoot);

            if (groupe != null)
                ((ViewModels.FenetreDossierViewModel?)DataContext)?.NouveauDossier(groupe);
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

        public async void NouvelleNote()
        {
            // We want a valid group and no other groups inside
            // because a group cannot contain marks and groups at the same time.
            var vm = (ViewModels.FenetreDossierViewModel?)DataContext;
            var dossier = vm?.Dossier;
            if (dossier != null && dossier.Groupes == null)
            {
                var window = new FenetreNouvelleNote();
                var note = await window.ShowDialog<Models.Note?>((Window?)VisualRoot);

                if (note != null)
                {
                    if (dossier.Notes == null)
                        dossier.Notes = new ObservableCollection<Models.Note>();

                    note.Parent = dossier;
                    dossier.Notes.Add(note);
                    dossier.UpdatePoints();
                }
            }
        }

        public async void NouveauGroupe()
        {
            // We want a valid group and no marks inside
            // because a group cannot contain marks and groups at the same time.
            var vm = (ViewModels.FenetreDossierViewModel?)DataContext;
            var dossier = vm?.Dossier;
            if (dossier != null && dossier.Notes == null)
            {
                var window = new FenetreNouveauGroupe();
                var childGroup = await window.ShowDialog<Models.Groupe?>((Window?)VisualRoot);

                if (childGroup != null)
                {
                    if (dossier.Groupes == null)
                        dossier.Groupes = new ObservableCollection<Models.Groupe>();

                    childGroup.Parent = dossier;
                    dossier.Groupes.Add(childGroup);
                }
            }
        }

        public void Quitter()
        {
            Close();
        }

    }
}
