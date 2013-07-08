using System.Windows.Controls;

namespace DiagramBuilder
{
    public partial class WarningPage : UserControl
    {
        public WarningPage(string domain)
        {
            InitializeComponent();
            WrongDomain.Text += domain;
        }
    }
}
