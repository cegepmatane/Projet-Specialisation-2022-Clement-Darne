using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Success_History.Models;


namespace Success_History.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            SerializeCommand = ReactiveCommand.Create(() =>
            {
                var test = new Test("Hello JSON");
                test.Serialize();
            });
            
            DeserializeCommand = ReactiveCommand.Create(() =>
            {
                var test = Test.Deserialize();
                if (test != null)
                    JsonText = test.Text;
            });
        }

        public string Greeting => "Welcome to Avalonia!";

        public ICommand SerializeCommand { get; }
        public ICommand DeserializeCommand { get; }

        private string? _jsonText = "";

        public string? JsonText
        {
            get => _jsonText;
            set => this.RaiseAndSetIfChanged(ref _jsonText, value);
        }
    }
}
