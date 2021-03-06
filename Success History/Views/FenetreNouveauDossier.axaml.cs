using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace Success_History.Views
{
    public partial class FenetreNouveauDossier : Window
    {
        public FenetreNouveauDossier()
        {
            InitializeComponent();

            Action<Models.Groupe?> action = (dossier) => Close(dossier);
            DataContext = new ViewModels.FenetreNouveauGroupeViewModel(action);

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
