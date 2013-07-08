using System.Collections.ObjectModel;

namespace DiagramBuilder.ViewModels
{
    public class DiagramBuilderViewModel : BaseViewModel
    {
        private ObservableCollection<DiagramControlViewModel> _diagramMainElements;

        public DiagramBuilderViewModel()
        {
            InitMenuControls();
        }

        public ObservableCollection<DiagramControlViewModel> DiagramMainElements
        {
            get 
            {
                return _diagramMainElements;
            }
            private set
            {
                if (_diagramMainElements != value)
                {
                    _diagramMainElements = value;
                    OnPropertyChanged("DiagramMainElements");
                }
            }
        }

        private void InitMenuControls()
        {
            _diagramMainElements = new ObservableCollection<DiagramControlViewModel>
                                       {
                                           new ActivityBoxViewModel {Name = "Activity Box"},
                                           new LabelControlViewModel {Name = "Label"},
                                           new LineControlViewModel {Name = "Line"}
                                       };
        }

    }
}
