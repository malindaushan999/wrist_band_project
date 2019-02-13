using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WristBandAPI.DataModel;

namespace WristBandAPI.Base
{
    /// <summary>
    ///  XXBT tables details
    /// </summary>
    public class XXBTData
    {
        public int Id { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Convert bm_xxbt --> XXBTData
        /// </summary>
        /// <param name="entity">bm_xxbt</param>
        public void SetEntity(xxbt_default entity)
        {
            this.Id = entity.id;
            this.Description = entity.description;
        }
    }

	public class User
	{

	}
}