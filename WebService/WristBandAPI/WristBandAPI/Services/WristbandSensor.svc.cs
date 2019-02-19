using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WristBandAPI.Common;
using WristBandAPI.DataModel;
using WristBandAPI.Sensor;

namespace WristBandAPI.Services
{
	public class WristbandSensor : IWristbandSensor
	{
		// define and initialize logger
		Logger logger = LogManager.GetCurrentClassLogger();

		// define and initialize dataase context
		WristbandEntities context = new WristbandEntities();

		/// <summary>
		/// Upload sensor data to server
		/// </summary>
		/// <param name="req">sensor data request</param>
		/// <returns>sensor data response</returns>
		public UploadSensorDataResponse UploadSensorData(UploadSensorDataRequest req)
		{
			logger.Debug("[BEGIN]");
			logger.Trace(CommonUtility.ToJson(req));

			// Define and Initialize response
			UploadSensorDataResponse res = new UploadSensorDataResponse();

			// Transaction start
			using (var dbTransactionContext = context.Database.BeginTransaction())
			{
				try
				{
					// Check sensor id exists
					var sensorInfo = context.sensor_info.Where(w => w.id == req.SensorId).FirstOrDefault();
					if (sensorInfo == null)
					{
						// If sensor id does not exists then attach error codes to response
						res.ResultCode = SensorErrors.SensorNotRegistered.eCode;
						res.ResultMessage = SensorErrors.SensorNotRegistered.eMsg;
						res.ExceptionMessage = null;

						// Write error to log
						CommonUtility.writeErrorLog("UploadSensorData", res, null, logger);

						// return response
						return res;
					}

					// create sensor_data entity to be updated
					sensor_data sensorData = new sensor_data();
					sensorData.sensor = sensorInfo.id;
					sensorData.data = req.Data;
					sensorData.timestamp = DateTime.Now;
					sensorData.is_delete = (short)ECDeleteType.NOT_DELETE;

					// add entity to dbContext
					context.sensor_data.Add(sensorData);

					// save changes to db
					context.SaveChanges();

					// commit db transaction
					dbTransactionContext.Commit();
				}
				catch (Exception ex)
				{
					// Rollback the database transaction context
					dbTransactionContext.Rollback();

					// Attach error codes to response
					res.ResultCode = CommonErrors.DBOperationError.eCode;
					res.ResultMessage = CommonErrors.DBOperationError.eMsg;
					res.ExceptionMessage = ex.InnerException.ToString();

					// Write exception to log
					CommonUtility.writeErrorLog("UploadSensorData", res, ex, logger);

					return res;
				}
			}

			// attach success result codes to response
			res.ResultCode = CommonErrors.SUCCESS.eCode;
			res.ResultMessage = CommonErrors.SUCCESS.eMsg;

			logger.Debug("[OK]");

			// return response
			return res;
		}
	}
}
