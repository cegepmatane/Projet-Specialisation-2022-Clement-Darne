using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Dialogs;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;


namespace Success_History.Views.Dialogs
{
    public class FichierDialogue
    {
        public static FichierDialogue Get()
        {
            return s_instance;
        }


        public async Task<string?> OuvrirDossier(Window parent)
        {
            var result = await new OpenFileDialog()
            {
                Title = "Ouvrir un dossier de notes.",
                Filters = GetFiltres(),
                Directory = _cheminRepertoire,
                InitialFileName = Assembly.GetEntryAssembly()?.GetModules().FirstOrDefault()?.FullyQualifiedName
            }.ShowAsync(parent);

            if (result == null || !result.Any())
                return null;
            else
                return (string?)result.GetValue(0);
        }

        public async Task<string?> SauvegarderDossier(Window parent, string initialFileName)
        {
            var result = await new SaveFileDialog()
            {
                Title = "Sauvegarder un dossier de notes.",
                Filters = GetFiltres(),
                Directory = _cheminRepertoire,
                InitialFileName = initialFileName
            }.ShowAsync(parent);

            return result;
        }


        private List<FileDialogFilter> GetFiltres()
        {
            // Filtres pour l'explorateur de fichiers.
            return new List<FileDialogFilter>
                {
                    new FileDialogFilter
                    {
                        Name = "Dossiers Success History",
                        Extensions = { "shist" }
                    },
                    new FileDialogFilter
                    {
                        Name = "Tous les fichiers",
                        Extensions = { "*" }
                    }
                };
        }

        private FichierDialogue()
        {

        }


        private static FichierDialogue s_instance = new FichierDialogue();

        // Répertoire HOME par défaut.
        private string _cheminRepertoire = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }

}
