using System.Windows.Controls;

namespace DiagramBuilder.Controls.DiagramControls
{
    public class ActivityBox : Control
    {
        public ActivityBox()
        {
            DefaultStyleKey = typeof (ActivityBox);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _processId = GetTemplateChild("processId") as TextBlock;
            _processName = GetTemplateChild("processName") as TextBlock;
        }

        private TextBlock _processId;
        private TextBlock _processName;

        public string ProcessName { get { return _processName.Text; } set { _processName.Text = value; } }

        public string ProcessId { get { return _processId.Text; } set { _processId.Text = value; } }

        public bool IsSubscribed { get; set; }
    }
}
