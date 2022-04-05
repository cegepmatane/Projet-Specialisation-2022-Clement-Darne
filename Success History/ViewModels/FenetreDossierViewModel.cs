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
using System.Collections.ObjectModel;

namespace Success_History.ViewModels
{
    public class FenetreDossierViewModel : ViewModelBase
    {
        public FenetreDossierViewModel()
        {
            // Dossier de test
#if DOSSIER_DEMO
            Models.Groupe dossier = new Models.Groupe();
            dossier.Nom = "DUT S3";
            dossier.Groupes = new ObservableCollection<Models.Groupe>();

            Models.Groupe maths = new Models.Groupe() { Nom = "Mathématiques" };
            maths.Notes = new ObservableCollection<Models.Note>();
            dossier.Groupes.Add(maths);
            
            Models.Groupe algo = new Models.Groupe() { Nom = "Algorithmique" };
            algo.Notes = new ObservableCollection<Models.Note>();
            dossier.Groupes.Add(algo);

            maths.Notes.Add(new Models.Note() { Points = 19.750f, Max = 20.000f, Description = "Chapitres 1, 2 et 3" });

            algo.Notes.Add(new Models.Note() { Points = 18.000f, Max = 20.000f, Description = "Chapitre 1" });
            algo.Notes.Add(new Models.Note() { Points = 15.000f, Max = 20.000f, Description = "Chapitre 2" });
            algo.Notes.Add(new Models.Note() { Points = 16.000f, Max = 20.000f, Description = "Chapitre 3" });

            Dossier = Models.Dossier.Init(dossier);
            Dossier.SetChildrenParent();
#endif

            _serialiseur = Models.SerialiseurDossier.Get();
            FichierExiste = false;
        }


        public void SauvegarderDossier(string? filePath = null)
        {
            // Anyway, _dossier cannot be null here.
            if (Dossier != null)
            {
                if (filePath != null)
                {
                    Dossier.FileName = Path.GetFileName(filePath);
                    Console.Out.WriteLine(Dossier.FileName);

                    string? directoryPath = Path.GetDirectoryName(filePath);
                    Dossier.DirectoryPath = (directoryPath != null) ? directoryPath : "";
                    
                    FichierExiste = true;
                }
                
                _serialiseur.Serialiser(Dossier);
            }
        }


        public void OuvrirDossier(string filePath)
        {
            // TODO: Ask if the user is willing to save its work before changing of file.
            Models.Groupe? dossier = _serialiseur.Deserialiser(filePath);
            if (dossier == null)
            {
                // TODO: Error message. Anyway, this should not happen as the file comes from the OpenFileDialog.
                return;
            }

            Dossier = Models.Dossier.Init(dossier);

            Dossier.FileName = Path.GetFileName(filePath);

            string? directoryPath = Path.GetDirectoryName(filePath);
            Dossier.DirectoryPath = (directoryPath != null) ? directoryPath : "";

            FichierExiste = true;
        }

        public void NouveauDossier(Models.Dossier dossier)
        {
            Dossier = dossier;
            FichierExiste = false;
        }


        public void OnDossierUpdate()
        {
            this.RaisePropertyChanged("Dossier");
        }



        private string _titreFenetre = "Success History";

        public string TitreFenetre
        {
            get => _titreFenetre;
            set => this.RaiseAndSetIfChanged(ref _titreFenetre, value);
        }


        private bool _fichierExiste;

        public bool FichierExiste
        {
            get => _fichierExiste;
            set => this.RaiseAndSetIfChanged(ref _fichierExiste, value);
        }


        private Models.Dossier? _dossier;

        public Models.Dossier? Dossier
        {
            get => _dossier;
            set
            {
                _dossier = value;

                if (_dossier != null)
                {
                    _dossier.SetChildrenParent();
                    TitreFenetre = _dossier.Nom + " - Success History";
                }
                else
                {
                    FichierExiste = false;
                    TitreFenetre = "Success History";
                }

                this.RaisePropertyChanged("Dossier");
            }
        }


        private Models.SerialiseurDossier _serialiseur;
    }
}
