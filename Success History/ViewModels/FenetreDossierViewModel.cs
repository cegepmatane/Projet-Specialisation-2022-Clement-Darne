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

namespace Success_History.ViewModels
{
    public class FenetreDossierViewModel : ViewModelBase
    {
        public FenetreDossierViewModel()
        {
            // Dossier de test
#if DOSSIER_DEMO
            Models.Groupe dossier = new Models.Groupe() { Nom = "DUT S3" };
            dossier.Groupes = new List<Models.Groupe>();

            Models.Groupe maths = new Models.Groupe() { Nom = "Mathématiques" };
            maths.Notes = new List<Models.Note>();
            dossier.Groupes.Add(maths);
            
            Models.Groupe algo = new Models.Groupe() { Nom = "Algorithmique" };
            algo.Notes = new List<Models.Note>();
            dossier.Groupes.Add(algo);

            maths.Notes.Add(new Models.Note() { Points = 19.750f, Max = 20.000f, Description = "Chapitres 1, 2 et 3" });

            algo.Notes.Add(new Models.Note() { Points = 18.000f, Max = 20.000f, Description = "Chapitre 1" });
            algo.Notes.Add(new Models.Note() { Points = 15.000f, Max = 20.000f, Description = "Chapitre 2" });
            algo.Notes.Add(new Models.Note() { Points = 16.000f, Max = 20.000f, Description = "Chapitre 3" });

            Dossier = dossier;
#endif

            _serialiseur = Models.SerialiseurDossier.Get();

            // Le lambda exécuté lors d'un clique sur le bouton "Sérialiser JSON".
            CommandeEnregistrer = ReactiveCommand.Create(() =>
            {
                EnregistrerDossier();
            });

            // Le lambda exécuté lors d'un clique sur le bouton "Désérialiser JSON".
            CommandeOuvrir = ReactiveCommand.Create(() =>
            {
                OuvrirDossier();
            });
        }


        public void EnregistrerDossier()
        {
            if (Dossier != null)
                _serialiseur.Serialiser(Dossier);
        }

        public void OuvrirDossier()
        {
            Dossier = _serialiseur.Deserialiser();
        }


        public ICommand CommandeEnregistrer { get; }
        public ICommand CommandeOuvrir { get; }


        private string _titreFenetre = "Success History";

        public string TitreFenetre
        {
            get => _titreFenetre;
            set => this.RaiseAndSetIfChanged(ref _titreFenetre, value);
        }


        private int _largeur = 960;

        public int Largeur
        {
            get => _largeur;
            set => this.RaiseAndSetIfChanged(ref _largeur, value);
        }

        private int _hauteur = 540;

        public int Hauteur
        {
            get => _hauteur;
            set => this.RaiseAndSetIfChanged(ref _hauteur, value);
        }

        private Models.Groupe? _dossier;

        public Models.Groupe? Dossier
        {
            get => _dossier;
            set
            {
                this.RaiseAndSetIfChanged(ref _dossier, value);

                if (Dossier != null)
                    TitreFenetre = Dossier.Nom + " - Success History";
                else
                    TitreFenetre = "Success History";
            }
        }


        private Models.SerialiseurDossier _serialiseur;
    }
}
