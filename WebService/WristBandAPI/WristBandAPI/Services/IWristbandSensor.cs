using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WristBandAPI.Sensor;

namespace WristBandAPI.Services
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWristbandSensor" in both code and config file together.
	[ServiceContract]
	public interface IWristbandSensor
	{
		/// <summary>
		/// Upload sensor data
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[OperationContract(Name = "UploadSensorData", Action = "/UploadSensorDataReq", ReplyAction = "/UploadSensorDataRes")]
		UploadSensorDataResponse UploadSensorData(UploadSensorDataRequest req);
	}
}
