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
    public class FenetreDossierViewModel : ViewModelBase
    {
        public FenetreDossierViewModel()
        {
            // Dossier de test
#if DOSSIER_DEMO
            Models.Dossier dossier = Models.Dossier.Init();
            dossier.Nom = "DUT S3";
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
        }


        public void SauvegarderDossier(string? filePath = null)
        {
            // Anyway, _dossier cannot be null here.
            if (_dossier != null)
            {
                if (filePath == null)
                {
                    filePath = Path.Combine(_dossier.DirectoryPath, _dossier.FileName);
                }
                else
                {
                    _dossier.FileName = Path.GetFileName(filePath);

                    string? directoryPath = Path.GetDirectoryName(filePath);
                    _dossier.DirectoryPath = (directoryPath != null) ? directoryPath : "";
                }
                
                _serialiseur.Serialiser(_dossier);
            }
        }


        public void OuvrirDossier()
        {
        }



        private string _titreFenetre = "Success History";

        public string TitreFenetre
        {
            get => _titreFenetre;
            set => this.RaiseAndSetIfChanged(ref _titreFenetre, value);
        }


        private Models.Dossier? _dossier;

        public Models.Dossier? Dossier
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
