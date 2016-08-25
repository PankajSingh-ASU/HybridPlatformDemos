// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TestInputs.iOS
{
	[Register("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton Button { get; set; }

		[Outlet]
		[GeneratedCode("iOS Designer", "1.0")]
		UIKit.UIButton ClickToStart { get; set; }

		[Action("Click To Start_TouchUpInside:")]
		[GeneratedCode("iOS Designer", "1.0")]
		partial void ClickToStart_TouchUpInside(UIKit.UIButton sender);

		void ReleaseDesignerOutlets()
		{
			if (Button != null)
			{
				Button.Dispose();
				Button = null;
			}

			if (ClickToStart != null)
			{
				ClickToStart.Dispose();
				ClickToStart = null;
			}
		}
	}
}
