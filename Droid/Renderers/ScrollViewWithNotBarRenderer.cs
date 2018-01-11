using System;
using System.ComponentModel;
using SegmentedControlSample.Controls;
using SegmentedControlSample.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScrollViewWithNotBar),typeof(ScrollViewWithNotBarRenderer))]
namespace SegmentedControlSample.Droid.Renderers
{
	public class ScrollViewWithNotBarRenderer : ScrollViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
				return;

			if (e.OldElement != null)
				e.OldElement.PropertyChanged -= OnElementPropertyChanged;

			e.NewElement.PropertyChanged += OnElementPropertyChanged;

		}

		protected void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.HorizontalScrollBarEnabled = false;
			this.VerticalScrollBarEnabled = false;

		}
	}
}
