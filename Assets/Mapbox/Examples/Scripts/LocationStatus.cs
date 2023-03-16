namespace Mapbox.Examples
{
	using Mapbox.Unity.Location;
	using UnityEngine;

	public class LocationStatus : MonoBehaviour
	{
		private AbstractLocationProvider _locationProvider = null;

		Location currLoc;
		void Start()
		{
			if (null == _locationProvider)
			{
				_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
			}
		}


		void Update()
		{
			currLoc = _locationProvider.CurrentLocation;
		}

		public double GetLocationLat()
		{
			return currLoc.LatitudeLongitude.x;
		}

		public double GetLocationLon()
		{
			return currLoc.LatitudeLongitude.y;
		}
	}
}
