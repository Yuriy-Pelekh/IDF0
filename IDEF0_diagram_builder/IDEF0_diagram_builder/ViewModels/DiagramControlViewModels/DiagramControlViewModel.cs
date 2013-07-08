
namespace DiagramBuilder.ViewModels
{
    public class DiagramControlViewModel : BaseViewModel
    {
        private string _name;

        private string _imageSource;
        
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }
    }
}
