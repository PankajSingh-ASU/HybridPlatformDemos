﻿using System;
using CoreLocation;
using UIKit;

namespace LocationDetailsIOS.iOS
{
	public class LocationManager
	{
		protected CLLocationManager locMgr;
		public event EventHandler<LocationUpdatedEventArgs> LocationUpdated = delegate { };

		public LocationManager()
		{
			this.locMgr = new CLLocationManager();
			this.locMgr.PausesLocationUpdatesAutomatically = false;

			// iOS 8 has additional permissions requirements
			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
			{
				//locMgr.RequestAlwaysAuthorization(); // works in background
				//locMgr.RequestAlwaysAuthorization("Testing Purpose");
				locMgr.RequestWhenInUseAuthorization (); // only in foreground
			}

			if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
			{
				locMgr.AllowsBackgroundLocationUpdates = true;
			}
		}

		public CLLocationManager LocMgr
		{
			get { return this.locMgr; }
		}
		public void startLocationUpdates()
		{
			if (CLLocationManager.LocationServicesEnabled)
			{
				//set the desired accuracy, in meters
				LocMgr.DesiredAccuracy = 1;
				LocMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
				{
					// fire our custom Location Updated event
					LocationUpdated(this, new LocationUpdatedEventArgs(e.Locations[e.Locations.Length - 1]));
				};
				LocMgr.StartUpdatingLocation();
			}

		}
		//This will keep going in the background and the foreground
		public void PrintLocation(object sender, LocationUpdatedEventArgs e)
		{

			CLLocation location = e.Location;
			Console.WriteLine("Altitude: " + location.Altitude + " meters");
			Console.WriteLine("Longitude: " + location.Coordinate.Longitude);
			Console.WriteLine("Latitude: " + location.Coordinate.Latitude);
			Console.WriteLine("Course: " + location.Course);
			Console.WriteLine("Speed: " + location.Speed);
		}
	}
}

