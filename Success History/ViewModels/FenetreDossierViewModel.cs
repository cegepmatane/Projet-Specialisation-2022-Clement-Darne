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

        public void NouveauDossier(Models.Groupe groupe)
        {
            Dossier = Models.Dossier.Init(groupe);
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
