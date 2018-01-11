using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace SegmentedControlSample
{
    public partial class SegmentedControlSamplePage : ContentPage
    {
        public SegmentedControlSamplePage()
        {
            InitializeComponent();
            var vehicleTypes = new List<string>() { "Car", "Motocycle", "Plane", "Boat", "Bike", "Jeep", "Train", "Truck" };
            segment.Children = vehicleTypes;
        }

        void Handle_ValueChanged(object sender, System.EventArgs e)
        {
            ItemSelectedText.Text = segment.ItemSelected;
        }
    }
}
