using System;
using System.ComponentModel;
using SegmentedControlSample.Controls;
using SegmentedControlSample.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScrollViewWithNotBar),typeof(ScrollViewWithNotBarRenderer))]
namespace SegmentedControlSample.iOS.Renderers
{
	public class ScrollViewWithNotBarRenderer : ScrollViewRenderer
	{
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
            {
                return;
            }

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;
            }

            e.NewElement.PropertyChanged += OnElementPropertyChanged;
		}

		private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.ShowsHorizontalScrollIndicator = false;
		}
	}
}