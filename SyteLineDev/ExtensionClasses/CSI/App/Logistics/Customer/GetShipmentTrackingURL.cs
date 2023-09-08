//PROJECT NAME: Logistics
//CLASS NAME: GetShipmentTrackingURL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetShipmentTrackingURL : IGetShipmentTrackingURL
	{
		readonly IApplicationDB appDB;
		
		
		public GetShipmentTrackingURL(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TrackingURL) GetShipmentTrackingURLSp(decimal? ShipmentID,
		string TrackingNumber = null,
		string TrackingURL = null)
		{
			ShipmentIDType _ShipmentID = ShipmentID;
			TrackingNumberType _TrackingNumber = TrackingNumber;
			URLType _TrackingURL = TrackingURL;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetShipmentTrackingURLSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentID", _ShipmentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrackingNumber", _TrackingNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrackingURL", _TrackingURL, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TrackingURL = _TrackingURL;
				
				return (Severity, TrackingURL);
			}
		}

		public string GetShipmentTrackingURLFn(
			decimal? ShipmentID,
			string TrackingNumber = null)
		{
			ShipmentIDType _ShipmentID = ShipmentID;
			TrackingNumberType _TrackingNumber = TrackingNumber;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetShipmentTrackingURL](@ShipmentID, @TrackingNumber)";

				appDB.AddCommandParameter(cmd, "ShipmentID", _ShipmentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrackingNumber", _TrackingNumber, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
