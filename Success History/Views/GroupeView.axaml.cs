using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        public async void NouvelleNote()
        {
            // We want a valid group and no other groups inside
            // because a group cannot contain marks and groups at the same time.
            var groupe = (Models.Groupe?)DataContext;
            if (groupe != null && groupe.Groupes == null)
            {
                var window = new FenetreNouvelleNote();
                var note = await window.ShowDialog<Models.Note?>((Window?)VisualRoot);
                
                if (note != null)
                {
                    if (groupe.Notes == null)
                        groupe.Notes = new ObservableCollection<Models.Note>();

                    note.Parent = groupe;
                    groupe.Notes.Add(note);
                    groupe.UpdatePoints();
                }
            }
        }

        public void NouveauGroupe()
        {
            // We want a valid group and no marks inside
            // because a group cannot contain marks and groups at the same time.
            /*var groupe = (Models.Groupe?)DataContext;
            if (groupe != null && groupe.Notes == null)
            {
                var window = new FenetreNouveauGroupe();
                var groupe = await window.ShowDialog<Models.Groupe?>((Window?)VisualRoot);

                if (groupe != null)
                {
                    if (groupe.Groupes == null)
                        groupe.Groupes = new ObservableCollection<Models.Groupe>();

                    groupe.Groupes.Add(groupe);
                }
            }*/
        }
    }
}
