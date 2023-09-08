//PROJECT NAME: Admin
//CLASS NAME: GetOpportunityTaskCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class GetOpportunityTaskCount : IGetOpportunityTaskCount
	{
		IApplicationDB appDB;
		
		
		public GetOpportunityTaskCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? TaskCount,
		int? DueCount,
		string Infobar) GetOpportunityTaskCountSp(string OppID,
		string Slsman,
		DateTime? StartDate,
		DateTime? EndDate,
		int? TaskCount,
		int? DueCount,
		string Infobar = null)
		{
			OpportunityIDType _OppID = OppID;
			SlsmanType _Slsman = Slsman;
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			IntType _TaskCount = TaskCount;
			IntType _DueCount = DueCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetOpportunityTaskCountSp";
				
				appDB.AddCommandParameter(cmd, "OppID", _OppID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskCount", _TaskCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DueCount", _DueCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaskCount = _TaskCount;
				DueCount = _DueCount;
				Infobar = _Infobar;
				
				return (Severity, TaskCount, DueCount, Infobar);
			}
		}
	}
}
