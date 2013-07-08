using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DiagramBuilder.Controls.DiagramControls;
using DiagramBuilder.DragDrop;

namespace DiagramBuilder.Controls
{
    public partial class DiagramBuilderView : UserControl
    {
        private readonly DragDropManager _dragManager;

        public DiagramBuilderView()
        {
            InitializeComponent();
            _dragManager = DragDropManager.Instance;
            _dragManager.AdornerArea = draggingArea;

            MouseMove += _dragManager.PanelMouseMove;
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var control = new ActivityBox() {Opacity = 0.7, Width = 200, Height = 100};
            control.MouseLeftButtonUp += MouseLeftButtonUp;
            
            _dragManager.DraggingElement = control;
            _dragManager.StartPoint = e.GetPosition(_dragManager.AdornerArea);
            _dragManager.DraggingStarted = true;
        }

        private void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //dragManager.StartPoint = e.GetPosition(dragManager.AdornerArea);
            _dragManager.DraggingStarted = false;
            _dragManager.DraggingElement.MouseLeftButtonUp -= MouseLeftButtonUp;

            var point = e.GetPosition(dropArea);
            AddElementInWorkingSpace(point);
            ShowPropertyWindow();
        }

        private void AddElementInWorkingSpace(Point mousePosition)
        {
            if (mousePosition.X > 0 && mousePosition.Y > 0)
            {
                var element = _dragManager.DraggingElement as ActivityBox;

                if (!element.IsSubscribed)
                {
                    element.IsSubscribed = true;
                    element.MouseLeftButtonDown += element_MouseLeftButtonDown;
                    element.MouseLeftButtonUp += element_MouseLeftButtonUp;
                }

                element.Opacity = 1.0;

                Canvas.SetLeft(element, mousePosition.X - element.Width / 2.0);
                Canvas.SetTop(element, mousePosition.Y - element.Height / 2.0);

                dropArea.Children.Add(element);
            }
        }

        private void element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;

            dropArea.Children.Remove(element);
            
            element.Opacity = 0.7;
            
            _dragManager.DraggingElement = element;
            _dragManager.StartPoint = e.GetPosition(_dragManager.AdornerArea);
            _dragManager.DraggingStarted = true;
        }

        private void element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _dragManager.DraggingStarted = false;

            var point = e.GetPosition(dropArea);
            AddElementInWorkingSpace(point);
        }

        private void ShowPropertyWindow()
        {
            var window = new ActivityBoxPropertyWindow(_dragManager.DraggingElement as ActivityBox);
            window.processId.Text = "A0";
            window.processName.Text = "Process Name";
            window.Show();
        }
    }
}
