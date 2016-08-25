using System;

using Android.App;
using Android.OS;
using Android.Widget;
namespace Phoneword
{
	[Activity(Label = "@string/callHistory")]
	public class CallHistoryActivity : ListActivity
	{
		//static readonly List<string> phoneNumbers = new List<string>();
		protected override void OnCreate(Bundle bundle)
		{

			base.OnCreate(bundle);
			System.Diagnostics.Debug.WriteLine("Inside CallHistoryActivity ");
			// Create your application here
			var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];
			Console.Write(phoneNumbers);
			this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, phoneNumbers);


		}
	}
}