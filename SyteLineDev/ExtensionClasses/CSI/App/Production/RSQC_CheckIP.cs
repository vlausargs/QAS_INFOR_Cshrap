//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckIP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class RSQC_CheckIP : IRSQC_CheckIP
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CheckIP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_CheckIPSp(string i_begjob,
		string i_endjob,
		string i_begsuffix,
		string i_endsuffix,
		DateTime? EarliestStartDate,
		DateTime? LatestStartDate,
		DateTime? EarliestJobEndDate,
		DateTime? LatestJobEndDate,
		int? EStartDateOffset = null,
		int? LStartDateOffset = null,
		int? EEndDateOffset = null,
		int? LEndDateOffset = null,
		string Infobar = null)
		{
			JobType _i_begjob = i_begjob;
			JobType _i_endjob = i_endjob;
			JobType _i_begsuffix = i_begsuffix;
			JobType _i_endsuffix = i_endsuffix;
			DateType _EarliestStartDate = EarliestStartDate;
			DateType _LatestStartDate = LatestStartDate;
			DateType _EarliestJobEndDate = EarliestJobEndDate;
			DateType _LatestJobEndDate = LatestJobEndDate;
			DateOffsetType _EStartDateOffset = EStartDateOffset;
			DateOffsetType _LStartDateOffset = LStartDateOffset;
			DateOffsetType _EEndDateOffset = EEndDateOffset;
			DateOffsetType _LEndDateOffset = LEndDateOffset;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CheckIPSp";
				
				appDB.AddCommandParameter(cmd, "i_begjob", _i_begjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_endjob", _i_endjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_begsuffix", _i_begsuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_endsuffix", _i_endsuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EarliestStartDate", _EarliestStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LatestStartDate", _LatestStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EarliestJobEndDate", _EarliestJobEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LatestJobEndDate", _LatestJobEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EStartDateOffset", _EStartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LStartDateOffset", _LStartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EEndDateOffset", _EEndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LEndDateOffset", _LEndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
