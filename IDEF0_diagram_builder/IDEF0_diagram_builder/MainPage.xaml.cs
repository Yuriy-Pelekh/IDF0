using System.Windows.Controls;
using DiagramBuilder.ViewModels;

namespace DiagramBuilder
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            Diagram.DataContext = new DiagramBuilderViewModel();
        }
    }
}
