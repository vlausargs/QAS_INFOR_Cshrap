//PROJECT NAME: Production
//CLASS NAME: JobBookingCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobBookingCheck : IJobBookingCheck
	{
		readonly IApplicationDB appDB;
		
		
		public JobBookingCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JobBookingCheckSp(string pJob,
		int? pSuffix,
		int? pOperNum,
		int? pComplete,
		decimal? pQtyComplete,
		decimal? pQtyScrapped,
		int? pHasLoc,
		string Infobar)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			OperNumType _pOperNum = pOperNum;
			ListYesNoType _pComplete = pComplete;
			QtyUnitType _pQtyComplete = pQtyComplete;
			QtyUnitType _pQtyScrapped = pQtyScrapped;
			ListYesNoType _pHasLoc = pHasLoc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobBookingCheckSp";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOperNum", _pOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pComplete", _pComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyComplete", _pQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyScrapped", _pQtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHasLoc", _pHasLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
