using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WristBandAPI.Sensor
{
	public static class SensorErrors
	{
		public static class SensorNotRegistered
		{
			public static readonly int eCode = 2001;
			public static readonly string eMsg = "Requested sensor had not been registered";
		}
	}
}