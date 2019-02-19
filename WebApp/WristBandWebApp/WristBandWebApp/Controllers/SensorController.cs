using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using WristBandWebApp.WBAPISensor;

namespace WristBandWebApp.Controllers
{
    public class SensorController : ApiController
    {
		[System.Web.Http.AcceptVerbs("GET", "POST")]
		public async Task<CSResponse> SensorData(string data, string id)
		{
			using (WBAPISensor.WristbandSensorClient client = new WBAPISensor.WristbandSensorClient())
			{
				UploadSensorDataRequest req = new UploadSensorDataRequest();
				req.Data = data;
				req.SensorId = Convert.ToInt64(id);
				req.SessionId = new Guid();
				var res = await client.UploadSensorDataAsync(req);

				if (res.ResultCode == 0)
				{
					return res;
				}
				return res;
				//return Json(res, JsonRequestBehavior.AllowGet);
			}
		}
	}
}
