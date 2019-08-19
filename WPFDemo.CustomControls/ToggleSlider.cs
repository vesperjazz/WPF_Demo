using System.Windows;
using System.Windows.Controls.Primitives;

namespace WPFDemo.CustomControls
{
    public class ToggleSlider : ToggleButton
    {
        static ToggleSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleSlider), 
                new FrameworkPropertyMetadata(typeof(ToggleSlider)));
        }
    }
}
