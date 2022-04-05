using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;


namespace Success_History.ViewModels
{
    public class FenetreNouvelleNoteViewModel : ViewModelBase
    {
        public FenetreNouvelleNoteViewModel(Action<Models.Note?> closeAction)
        {
            _closeAction = closeAction;
        }
        

        public void Cancel()
        {
            _closeAction(null);
        }

        public void Submit()
        {
            Models.Note note = new Models.Note()
            {
                Points = Points,
                Max = Max,
                Coefficient = Coefficient,
                Description = Description
            };

            _closeAction(note);
        }


        private float _points = 20.0f;

        public float Points
        {
            get => _points;
            set => this.RaiseAndSetIfChanged(ref _points, value);
        }

        private float _max = 20.0f;

        public float Max
        {
            get => _max;
            set => this.RaiseAndSetIfChanged(ref _max, value);
        }

        private float _coefficient = 1.0f;

        public float Coefficient
        {
            get => _coefficient;
            set => this.RaiseAndSetIfChanged(ref _coefficient, value);
        }

        private string _description = "Sans détail.";

        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }


        private Action<Models.Note?> _closeAction;
    }
}
