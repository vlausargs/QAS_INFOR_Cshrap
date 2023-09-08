//PROJECT NAME: Logistics
//CLASS NAME: SetPartnerGPSLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SetPartnerGPSLoc : ISetPartnerGPSLoc
	{
		readonly IApplicationDB appDB;
		
		
		public SetPartnerGPSLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SetPartnerGPSLocSp(string PartnerId,
		decimal? Latitude,
		decimal? Longitude,
		DateTime? LocDate,
		int? GPSOnline)
		{
			FSPartnerType _PartnerId = PartnerId;
			FSGPSLocType _Latitude = Latitude;
			FSGPSLocType _Longitude = Longitude;
			DateTimeType _LocDate = LocDate;
			ListYesNoType _GPSOnline = GPSOnline;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetPartnerGPSLocSp";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Latitude", _Latitude, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Longitude", _Longitude, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocDate", _LocDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GPSOnline", _GPSOnline, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
