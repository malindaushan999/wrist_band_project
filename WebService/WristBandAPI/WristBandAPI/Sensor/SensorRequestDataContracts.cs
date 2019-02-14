using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WristBandAPI.Common;

namespace WristBandAPI.Sensor
{
	/// <summary>
	/// Request message for UploadSensorData api function
	/// </summary>
	[DataContract]
	public class UploadSensorDataRequest : Request
	{
		// Sensor ID
		[DataMember]
		public long SensorId { get; set; }

		// Sensor Data
		[DataMember]
		public string Data { get; set; }

		public UploadSensorDataRequest()
		{

		}
	}
}