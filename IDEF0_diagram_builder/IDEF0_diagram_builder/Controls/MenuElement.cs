using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DiagramBuilder.Controls
{
    public class MenuElement : Control
    {
        public MenuElement()
        {
            this.DefaultStyleKey = typeof(MenuElement);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text",
            typeof(string), typeof(MenuElement), null);

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource",
            typeof(string), typeof(MenuElement), null);

        public string Text
        {
            get { return (string)GetValue(MenuElement.TextProperty); }
            set { SetValue(MenuElement.TextProperty, value); }
        }

        public string ImageSource
        {
            get { return (string)GetValue(MenuElement.ImageSourceProperty); }
            set { SetValue(MenuElement.ImageSourceProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var image = GetTemplateChild("image") as Image;
            var textBlock = GetTemplateChild("textBlock") as TextBlock;

            if (image != null && !string.IsNullOrEmpty(ImageSource))
            {
                image.Source = new BitmapImage(new Uri(ImageSource, UriKind.RelativeOrAbsolute));
            }
            if (textBlock != null)
            {
                textBlock.Text = Text;
            }

            //this.MouseLeftButtonDown += new MouseButtonEventHandler(MenuElement_MouseLeftButtonDown);
        }
    }
}
