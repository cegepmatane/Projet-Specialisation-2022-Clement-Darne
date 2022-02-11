using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Success_History.Models;


namespace Success_History.ViewModels
{
    public class FenetrePrincipaleViewModel : ViewModelBase
    {
        public FenetrePrincipaleViewModel()
        {
            // Le lambda exécuté lors d'un clique sur le bouton "Sérialiser JSON".
            CommandeSerialiser = ReactiveCommand.Create(() =>
            {
                var test = new Test("Hello JSON");
                test.Serialiser();
            });

            // Le lambda exécuté lors d'un clique sur le bouton "Désérialiser JSON".
            CommandeDeserialiser = ReactiveCommand.Create(() =>
            {
                var test = Test.Deserialiser();
                if (test != null)
                    TexteJSON = test.Texte;
            });
        }

        public ICommand CommandeSerialiser { get; }
        public ICommand CommandeDeserialiser { get; }

        private string? _texteJSON = "";

        public string? TexteJSON
        {
            get => _texteJSON;
            set => this.RaiseAndSetIfChanged(ref _texteJSON, value);
        }
    }
}
