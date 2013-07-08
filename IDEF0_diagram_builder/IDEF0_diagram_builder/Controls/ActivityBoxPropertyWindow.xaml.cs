using System.Windows;
using System.Windows.Controls;
using DiagramBuilder.Controls.DiagramControls;

namespace DiagramBuilder.Controls
{
    public partial class ActivityBoxPropertyWindow : ChildWindow
    {
        private readonly ActivityBox _element;
        
        public ActivityBoxPropertyWindow()
        {
            InitializeComponent();
        }

        public ActivityBoxPropertyWindow(ActivityBox element)
        {
            InitializeComponent();

            _element = element;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            if (_element!= null)
            {
                _element.ProcessName = processName.Text;
                _element.ProcessId = processId.Text;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

