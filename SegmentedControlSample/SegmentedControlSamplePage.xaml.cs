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
            var vehicleTypes = new List<string>() {  "Motocycle", "Car", "Plane", "Boat", "Bike", "Jeep", "Train", "Truck" };
            segment.Children = vehicleTypes;
        }

        void Handle_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            ItemSelectedText.Text = $"{e.SelectedItem}";
        }
    }
}
