using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WristBandAPI.DataModel;

namespace WristBandAPI.Sensor
{
	public class SensorData
	{
		public long Id { get; set; }
		public long? SensorId { get; set; }
		public string Data { get; set; }
		public DateTime? Timestamp { get; set; }

		public void SetEntity(sensor_data entity)
		{
			this.Id = entity.id;
			this.SensorId = entity.sensor;
			this.Data = entity.data;
			this.Timestamp = entity.timestamp;
		}
	}

	public class SensorInfo
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string SerialNo { get; set; }
		public string Description { get; set; }
		public long? SensorType { get; set; }
		public long? AddedBy { get; set; }
		public DateTime? AddedDateTime { get; set; }
		public long? ModifiedBy { get; set; }
		public DateTime? ModifiedDateTime { get; set; }

		public void SetEntity(sensor_info entity)
		{
			this.Id = entity.id;
			this.Name = entity.name;
			this.SerialNo = entity.serial_no;
			this.Description = entity.description;
			this.SensorType = entity.sensor_type;
			this.AddedBy = entity.added_by;
			this.AddedDateTime = entity.added_datetime;
			this.ModifiedBy = entity.modified_by;
			this.ModifiedDateTime = entity.modified_datetime;
		}
	}
}