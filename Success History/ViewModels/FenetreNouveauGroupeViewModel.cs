#define DOSSIER_DEMO

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using ReactiveUI;
using System.Text.Json;
using Avalonia.Controls;


namespace Success_History.ViewModels
{
    public class FenetreNouveauGroupeViewModel : ViewModelBase
    {
        public FenetreNouveauGroupeViewModel(Action<Models.Groupe?> closeAction)
        {
            var groupe = new Models.Groupe();
            if (groupe != null)
            {
                Nom = groupe.Nom;
                Max = groupe.Max;
            }

            CloseAction = closeAction;
        }


        public void Cancel()
        {
            CloseAction(null);
        }

        public void Submit()
        {
            var groupe = new Models.Groupe()
            {
                Nom = Nom,
                Max = Max
            };

            CloseAction(groupe);
        }

        public Action<Models.Groupe?> CloseAction { get; set; }



        private string _nom = "Sans titre";

        public string Nom
        {
            get => _nom;
            set => this.RaiseAndSetIfChanged(ref _nom, value);
        }


        private float _max = 20.0f;

        public float Max
        {
            get => _max;
            set => this.RaiseAndSetIfChanged(ref _max, value);
        }

    }
}