using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace Success_History.Views
{
    public partial class FenetreNouvelleNote : Window
    {
        public FenetreNouvelleNote()
        {
            InitializeComponent();

            Action<Models.Note?> action = (note) => { Close(note); };
            var vm = new ViewModels.FenetreNouvelleNoteViewModel(action);

            DataContext = vm;
            
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
