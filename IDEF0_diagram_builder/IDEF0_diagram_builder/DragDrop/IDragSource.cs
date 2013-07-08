using System.Windows;

namespace DiagramBuilder.DragDrop
{
    public interface IDragSource
    {
        FrameworkElement DraggingElement
        { get; set; }
    }
}
