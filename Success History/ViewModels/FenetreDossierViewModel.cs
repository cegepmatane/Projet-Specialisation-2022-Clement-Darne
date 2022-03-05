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
            _dossier = new Models.Groupe() { Nom = "DUT S3" };
            _dossier.Groupes = new List<Models.Groupe>();

            Models.Groupe maths = new Models.Groupe() { Nom = "Mathématiques" };
            maths.Notes = new List<Models.Note>();
            _dossier.Groupes.Add(maths);
            
            Models.Groupe algo = new Models.Groupe() { Nom = "Algorithmique" };
            algo.Notes = new List<Models.Note>();
            _dossier.Groupes.Add(algo);

            maths.Notes.Add(new Models.Note() { Points = 19750, Max = 20000, Description = "Chapitres 1, 2 et 3" });

            algo.Notes.Add(new Models.Note() { Points = 18000, Max = 20000, Description = "Chapitre 1" });
            algo.Notes.Add(new Models.Note() { Points = 15000, Max = 20000, Description = "Chapitre 2" });
            algo.Notes.Add(new Models.Note() { Points = 16000, Max = 20000, Description = "Chapitre 3" });
#endif

            // Le lambda exécuté lors d'un clique sur le bouton "Sérialiser JSON".
            CommandeSerialiser = ReactiveCommand.Create(() =>
            {
                EnregistrerDossier();
            });

            // Le lambda exécuté lors d'un clique sur le bouton "Désérialiser JSON".
            CommandeDeserialiser = ReactiveCommand.Create(() =>
            {
                OuvrirDossier();
            });
        }


        public void EnregistrerDossier()
        {
            if (_dossier != null)
            {
                // Création du dossier s'il n'existe pas encore.
                if (!Directory.Exists(_cheminRepertoireDossier))
                {
                    Directory.CreateDirectory(_cheminRepertoireDossier);
                }

                string stringJSON = JsonSerializer.Serialize(_dossier);
                File.WriteAllText(_cheminRepertoireDossier + "/dossier.json", stringJSON);
            }
        }

        public void OuvrirDossier()
        {
            // Le fichier n'existe pas forcément.
            try
            {
                string stringJSON = File.ReadAllText(_cheminRepertoireDossier + "/dossier.json");
                _dossier = JsonSerializer.Deserialize<Models.Groupe>(stringJSON);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                _dossier = null;
            }

            if (_dossier != null)
                TitreFenetre = _dossier.Nom + " - Success History";
            else
                TitreFenetre = "Success History";
        }

        private static string InitialiserCheminRepertoireJSON()
        {
            string cheminEXE = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string? cheminRepertoire = Path.GetDirectoryName(cheminEXE);
            if (cheminRepertoire == null)
                return "./data";
            else
                return cheminRepertoire + "/data";
        }


        public ICommand CommandeSerialiser { get; }
        public ICommand CommandeDeserialiser { get; }


        private string _titreFenetre = "Success History";

        public string TitreFenetre
        {
            get => _titreFenetre;
            set => this.RaiseAndSetIfChanged(ref _titreFenetre, value);
        }

        private Models.Groupe? _dossier;
        private string _cheminRepertoireDossier = InitialiserCheminRepertoireJSON();
    }
}
