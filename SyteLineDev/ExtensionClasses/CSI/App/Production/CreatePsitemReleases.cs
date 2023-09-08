//PROJECT NAME: Production
//CLASS NAME: CreatePsitemReleases.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CreatePsitemReleases : ICreatePsitemReleases
	{
		readonly IApplicationDB appDB;
		
		
		public CreatePsitemReleases(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Suffix,
		string Infobar) CreatePsitemReleasesSp(int? InsertFlag,
		string Job,
		int? Suffix,
		DateTime? EndDate,
		string Status,
		string OldStatus,
		decimal? QtyReleased,
		string Infobar)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			DateType _EndDate = EndDate;
			JobStatusType _Status = Status;
			JobStatusType _OldStatus = OldStatus;
			QtyUnitType _QtyReleased = QtyReleased;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreatePsitemReleasesSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldStatus", _OldStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReleased", _QtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Suffix = _Suffix;
				Infobar = _Infobar;
				
				return (Severity, Suffix, Infobar);
			}
		}
	}
}
