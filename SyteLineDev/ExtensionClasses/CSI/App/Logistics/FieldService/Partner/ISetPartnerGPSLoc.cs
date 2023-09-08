//PROJECT NAME: Logistics
//CLASS NAME: ISetPartnerGPSLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISetPartnerGPSLoc
	{
		int? SetPartnerGPSLocSp(string PartnerId,
		decimal? Latitude,
		decimal? Longitude,
		DateTime? LocDate,
		int? GPSOnline);
	}
}

