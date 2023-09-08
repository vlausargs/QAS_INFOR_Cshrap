//PROJECT NAME: Logistics
//CLASS NAME: FTSLCheckQtyOnCloseJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLCheckQtyOnCloseJob : IFTSLCheckQtyOnCloseJob
	{
		readonly IApplicationDB appDB;
		
		
		public FTSLCheckQtyOnCloseJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? OperQtyComplete,
		decimal? OperQtyMoved,
		string Infobar) FTSLCheckQtyOnCloseJobSp(string Job,
		int? Suffix,
		int? OperNum,
		decimal? OperQtyComplete,
		decimal? OperQtyMoved,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			QtyUnitNoNegType _OperQtyComplete = OperQtyComplete;
			QtyUnitNoNegType _OperQtyMoved = OperQtyMoved;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLCheckQtyOnCloseJobSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperQtyComplete", _OperQtyComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperQtyMoved", _OperQtyMoved, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OperQtyComplete = _OperQtyComplete;
				OperQtyMoved = _OperQtyMoved;
				Infobar = _Infobar;
				
				return (Severity, OperQtyComplete, OperQtyMoved, Infobar);
			}
		}
	}
}
