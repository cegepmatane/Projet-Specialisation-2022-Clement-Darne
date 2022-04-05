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
    public class FenetreNouveauDossierViewModel : ViewModelBase
    {
        public FenetreNouveauDossierViewModel(Action<Models.Dossier?> closeAction)
        {
            var dossier = new Models.Groupe();
            if (dossier != null)
            {
                Nom = dossier.Nom;
                Max = dossier.Max;
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

            var dossier = Models.Dossier.Init(groupe);

            CloseAction(dossier);
        }

        public Action<Models.Dossier?> CloseAction { get; set; }



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