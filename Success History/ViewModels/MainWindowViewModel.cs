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
        }

        public string Greeting => "Welcome to Avalonia!";

        public ICommand SerializeCommand { get; }
    }
}
