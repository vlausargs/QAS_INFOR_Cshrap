//PROJECT NAME: Logistics
//CLASS NAME: SchedUpdateApptDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedUpdateApptDetail : ISchedUpdateApptDetail
	{
		readonly IApplicationDB appDB;
		
		
		public SchedUpdateApptDetail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SchedUpdateApptDetailSp(Guid? RowPointer,
		DateTime? RecordDate,
		int? StatCodeChanged = 0,
		string StatCode = null,
		string PartnerID = null,
		int? GPSOnline = 0,
		decimal? Latitude = null,
		decimal? Longitude = null,
		DateTime? GPSLocDate = null,
		int? NotesChanged = 0,
		string Notes = null,
		string Infobar = null)
		{
			RowPointerType _RowPointer = RowPointer;
			DateType _RecordDate = RecordDate;
			ListYesNoType _StatCodeChanged = StatCodeChanged;
			FSApptStatType _StatCode = StatCode;
			FSPartnerType _PartnerID = PartnerID;
			ListYesNoType _GPSOnline = GPSOnline;
			FSGPSLocType _Latitude = Latitude;
			FSGPSLocType _Longitude = Longitude;
			DateType _GPSLocDate = GPSLocDate;
			ListYesNoType _NotesChanged = NotesChanged;
			FSNotesType _Notes = Notes;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SchedUpdateApptDetailSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatCodeChanged", _StatCodeChanged, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatCode", _StatCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GPSOnline", _GPSOnline, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Latitude", _Latitude, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Longitude", _Longitude, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GPSLocDate", _GPSLocDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NotesChanged", _NotesChanged, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Notes", _Notes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
