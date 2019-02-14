using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WristBandAPI.Common;

namespace WristBandAPI.Sensor
{
	/// <summary>
	/// Response message for UploadSensorData api function
	/// </summary>
	[DataContract]
	public class UploadSensorDataResponse : CSResponse
	{
		public UploadSensorDataResponse()
		{

		}
	}
}