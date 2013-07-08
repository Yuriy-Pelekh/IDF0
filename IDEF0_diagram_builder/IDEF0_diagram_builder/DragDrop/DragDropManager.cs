using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DiagramBuilder.DragDrop
{
    public class DragDropManager
    {
        private static DragDropManager _instance;
        public static DragDropManager Instance
        {
            get { return _instance ?? (_instance = new DragDropManager()); }
        }

        //public IDragSource DragSource
        //{
        //    get;
        //    set;
        //}

        public FrameworkElement DraggingElement { get; set; }
        public Canvas AdornerArea { get; set; }
        public Point StartPoint { get; set; }

        private bool _draggingStarted;
        public bool DraggingStarted
        {
            get
            {
                return _draggingStarted;
            }
            set
            {
                if (value)
                {
                    PrepareToDraging();
                }
                else
                {
                    PrepareToDroping();
                }
                _draggingStarted = value;
            }
        }

        private FrameworkElement visualDraggingElement;

        private void PrepareToDraging()
        {
            DraggingElement.CaptureMouse();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            AdornerArea.Children.Add(DraggingElement);
        }

        private void PrepareToDroping()
        {
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
            AdornerArea.Children.Remove(DraggingElement);
            DraggingElement.ReleaseMouseCapture();
        }

        private Point _currentPoint = new Point(100,100);

        public void PanelMouseMove(object sender, MouseEventArgs e)
        {
            _currentPoint = e.GetPosition(AdornerArea);
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            DraggingElement.SetValue(Canvas.LeftProperty, _currentPoint.X - DraggingElement.ActualWidth/2.0);
            DraggingElement.SetValue(Canvas.TopProperty, _currentPoint.Y - DraggingElement.ActualHeight/2.0);
        }
    }
}
