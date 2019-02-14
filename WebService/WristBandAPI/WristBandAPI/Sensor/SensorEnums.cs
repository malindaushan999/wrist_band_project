using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WristBandAPI.Sensor
{
	[DataContract(Name = "ESSensorType")]
	public enum EBUserType
	{
		[EnumMember]
		HEART_BEAT_SENSOR = 0,

		[EnumMember]
		BLOOD_PRESSURE_SENSOR = 1,

		[EnumMember]
		TEMPARATURE_SENSOR = 1
	}
}