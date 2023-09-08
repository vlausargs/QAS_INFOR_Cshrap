//PROJECT NAME: Material
//CLASS NAME: PurgeEDIPlanningSchedules.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IPurgeEDIPlanningSchedules
	{
		(int? ReturnCode, string Infobar) PurgeEDIPlanningSchedulesSp(string ExOptBegVend_Num = null,
		string ExOptEndVend_Num = null,
		int? ExOptBegSched_Num = null,
		int? ExOptEndSched_Num = null,
		DateTime? ExOptBegPost_Date = null,
		DateTime? ExOptEndPost_Date = null,
		string ExOptprPostedEmp = null,
		short? CDateStartingOffset = null,
		short? CDateEndingOffset = null,
		string Infobar = null);
	}
	
	public class PurgeEDIPlanningSchedules : IPurgeEDIPlanningSchedules
	{
		readonly IApplicationDB appDB;
		
		public PurgeEDIPlanningSchedules(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PurgeEDIPlanningSchedulesSp(string ExOptBegVend_Num = null,
		string ExOptEndVend_Num = null,
		int? ExOptBegSched_Num = null,
		int? ExOptEndSched_Num = null,
		DateTime? ExOptBegPost_Date = null,
		DateTime? ExOptEndPost_Date = null,
		string ExOptprPostedEmp = null,
		short? CDateStartingOffset = null,
		short? CDateEndingOffset = null,
		string Infobar = null)
		{
			VendNumType _ExOptBegVend_Num = ExOptBegVend_Num;
			VendNumType _ExOptEndVend_Num = ExOptEndVend_Num;
			EdiSchedNumType _ExOptBegSched_Num = ExOptBegSched_Num;
			EdiSchedNumType _ExOptEndSched_Num = ExOptEndSched_Num;
			DateType _ExOptBegPost_Date = ExOptBegPost_Date;
			DateType _ExOptEndPost_Date = ExOptEndPost_Date;
			StringType _ExOptprPostedEmp = ExOptprPostedEmp;
			DateOffsetType _CDateStartingOffset = CDateStartingOffset;
			DateOffsetType _CDateEndingOffset = CDateEndingOffset;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeEDIPlanningSchedulesSp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegVend_Num", _ExOptBegVend_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndVend_Num", _ExOptEndVend_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSched_Num", _ExOptBegSched_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndSched_Num", _ExOptEndSched_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegPost_Date", _ExOptBegPost_Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndPost_Date", _ExOptEndPost_Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPostedEmp", _ExOptprPostedEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateStartingOffset", _CDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateEndingOffset", _CDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
