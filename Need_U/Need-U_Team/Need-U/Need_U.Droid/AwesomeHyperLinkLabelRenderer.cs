using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

using Android.Text.Util;
using Android.Util;
using Need_U;
using Need_U.Droid;

[assembly: ExportRenderer(typeof(AwesomeHyperLinkLabel), typeof(AwesomeHyperLinkLabelRenderer))]

namespace Need_U.Droid
{
    class AwesomeHyperLinkLabelRenderer : LabelRenderer
    {



        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (AwesomeHyperLinkLabel)Element;
            if (view == null) return;

            TextView textView = new TextView(Forms.Context);
            textView.LayoutParameters = new LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            textView.SetTextColor(view.TextColor.ToAndroid());

            // Setting the auto link mask to capture all types of link-able data
            textView.AutoLinkMask = MatchOptions.All;
            // Make sure to set text after setting the mask
            textView.Text = view.Text;
            textView.SetTextSize(ComplexUnitType.Dip, (float)view.FontSize);

            // overriding Xamarin Forms Label and replace with our native control
            SetNativeControl(textView);
        }




    }
}