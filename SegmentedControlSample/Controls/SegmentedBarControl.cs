using System;
using System.Collections.Generic;
using System.Linq;
using SegmentedControlSample.Controls;
using Xamarin.Forms;

namespace SegmentedControlSample
{
    public class SegmentedBarControl: ScrollViewWithNotBar
    {
		public static readonly BindableProperty ItemSelectedProperty = BindableProperty.Create(nameof(ItemSelected), typeof(string), typeof(SegmentedBarControl), null);
		public static readonly BindableProperty ChildrenProperty = BindableProperty.Create(nameof(Children), typeof(List<string>), typeof(SegmentedBarControl), null);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(SegmentedBarControl), Color.Black);
        public static readonly BindableProperty SelectedLineColorProperty = BindableProperty.Create(nameof(SelectedLineColor), typeof(Color), typeof(SegmentedBarControl), Color.Blue);
        public static readonly BindableProperty AutoScrollProperty = BindableProperty.Create(nameof(AutoScroll), typeof(bool), typeof(SegmentedBarControl), true);

        public delegate void ValueChangedEventHandler(object sender, EventArgs e);
        public event ValueChangedEventHandler ValueChanged;

		public string ItemSelected
		{
			get
			{
				return (string)GetValue(ItemSelectedProperty);
			}
			set
			{
				SetValue(ItemSelectedProperty, value);
                ValueChanged(this, new EventArgs());
			}
		}

		public List<string> Children
		{
			get
			{
				return (List<string>)GetValue(ChildrenProperty);
			}
			set
			{
                SetValue(ChildrenProperty, value);
			}
		}

        public Color TextColor
		{
			get
			{
				return (Color)GetValue(TextColorProperty);
			}
			set
			{
				SetValue(TextColorProperty, value);
			}
		}

       
		public Color SelectedLineColor
		{
			get
			{
				return (Color)GetValue(SelectedLineColorProperty);
			}
			set
			{
				SetValue(SelectedLineColorProperty, value);
			}
		}

        public bool AutoScroll
        {
            get
            {
                return (bool)GetValue(AutoScrollProperty);
            }
            set
            {
                SetValue(AutoScrollProperty, value);
            }
        }


        StackLayout _mainContentLayout = new StackLayout(){ Spacing = 10, Orientation = StackOrientation.Horizontal };
        StackLayout _lastElementSelected;
        public SegmentedBarControl(){
            VerticalOptions = LayoutOptions.Start;
            Orientation = ScrollOrientation.Horizontal;
            VerticalOptions = LayoutOptions.Fill;
        }

        void LoadChildrens(){
          
            _mainContentLayout.Children.Clear();
            foreach (var item in Children)
            {
				var label = new Label()
				{
					Text = item,
                    TextColor=TextColor,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				};

                var boxview = new BoxView() { BackgroundColor = Color.Transparent, HeightRequest = 2, HorizontalOptions = LayoutOptions.FillAndExpand };
                var childrenLayout = new StackLayout(){Spacing=0};

                childrenLayout.Children.Add(label);
                childrenLayout.Children.Add(boxview);
                childrenLayout.ClassId = item;
				_mainContentLayout.Children.Add(childrenLayout);
				var tapGestureRecognizer = new TapGestureRecognizer();
				tapGestureRecognizer.Tapped += (s, e) => {
                    ItemSelected = ((StackLayout)s).ClassId;
				};
				childrenLayout.GestureRecognizers.Add(tapGestureRecognizer);
            }

        }

        void SelectElement(StackLayout itemSelected){
			if (_lastElementSelected != null)
                (_lastElementSelected.Children.First(p=>p is BoxView) as BoxView).BackgroundColor = Color.Transparent;
			
            (itemSelected.Children.First(p => p is BoxView) as BoxView).BackgroundColor = SelectedLineColor;
			_lastElementSelected = itemSelected;

            if(AutoScroll)
			    this.ScrollToAsync(itemSelected, ScrollToPosition.MakeVisible, true);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == ItemSelectedProperty.PropertyName && Children != null && Children.Count > 0){
                SelectElement(_mainContentLayout.Children[Children.IndexOf(ItemSelected)] as StackLayout);
            } else  if (propertyName == ChildrenProperty.PropertyName && Children != null)
			{
				LoadChildrens();
                this.Content = _mainContentLayout;
                if(string.IsNullOrEmpty(ItemSelected)){
					ItemSelected = Children.First();
                }else{
					SelectElement(_mainContentLayout.Children[Children.IndexOf(ItemSelected)] as StackLayout);
                }
			}
        }
    }
}
