//PROJECT NAME: Production
//CLASS NAME: JobPMessages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobPMessages : IJobPMessages
	{
		readonly IApplicationDB appDB;
		
		
		public JobPMessages(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JobPMessagesSp(int? TNone,
		int? TMatCount,
		int? TClsCount,
		int? ErrorOccurred,
		decimal? CurTransNum,
		string Infobar)
		{
			ListYesNoType _TNone = TNone;
			GenericNoType _TMatCount = TMatCount;
			GenericNoType _TClsCount = TClsCount;
			ListYesNoType _ErrorOccurred = ErrorOccurred;
			HugeTransNumType _CurTransNum = CurTransNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobPMessagesSp";
				
				appDB.AddCommandParameter(cmd, "TNone", _TNone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMatCount", _TMatCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TClsCount", _TClsCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorOccurred", _ErrorOccurred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurTransNum", _CurTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
