//PROJECT NAME: Production
//CLASS NAME: JobRoutesOEE.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobRoutesOEE : IJobRoutesOEE
	{
		readonly IApplicationDB appDB;
		
		
		public JobRoutesOEE(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? Availability,
		decimal? Performance,
		decimal? Quality,
		decimal? OEE,
		decimal? TotalPieces,
		decimal? GoodPieces,
		decimal? OperatingTime,
		decimal? AvailableProdTime,
		decimal? UnavailableProdTime) JobRoutesOEESp(string ResourceGroup,
		string ResourceId,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		decimal? Availability = null,
		decimal? Performance = null,
		decimal? Quality = null,
		decimal? OEE = null,
		decimal? TotalPieces = null,
		decimal? GoodPieces = null,
		decimal? OperatingTime = null,
		decimal? AvailableProdTime = null,
		decimal? UnavailableProdTime = null)
		{
			ApsResgroupType _ResourceGroup = ResourceGroup;
			ApsResourceType _ResourceId = ResourceId;
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			DecimalType _Availability = Availability;
			DecimalType _Performance = Performance;
			DecimalType _Quality = Quality;
			DecimalType _OEE = OEE;
			QtyUnitType _TotalPieces = TotalPieces;
			QtyUnitType _GoodPieces = GoodPieces;
			TotalHoursType _OperatingTime = OperatingTime;
			DecimalType _AvailableProdTime = AvailableProdTime;
			DecimalType _UnavailableProdTime = UnavailableProdTime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobRoutesOEESp";
				
				appDB.AddCommandParameter(cmd, "ResourceGroup", _ResourceGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceId", _ResourceId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Availability", _Availability, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Performance", _Performance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Quality", _Quality, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OEE", _OEE, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotalPieces", _TotalPieces, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GoodPieces", _GoodPieces, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperatingTime", _OperatingTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AvailableProdTime", _AvailableProdTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnavailableProdTime", _UnavailableProdTime, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Availability = _Availability;
				Performance = _Performance;
				Quality = _Quality;
				OEE = _OEE;
				TotalPieces = _TotalPieces;
				GoodPieces = _GoodPieces;
				OperatingTime = _OperatingTime;
				AvailableProdTime = _AvailableProdTime;
				UnavailableProdTime = _UnavailableProdTime;
				
				return (Severity, Availability, Performance, Quality, OEE, TotalPieces, GoodPieces, OperatingTime, AvailableProdTime, UnavailableProdTime);
			}
		}
	}
}
