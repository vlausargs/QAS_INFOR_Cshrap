//PROJECT NAME: Logistics
//CLASS NAME: FTSLCheckQtyReceived.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLCheckQtyReceived : IFTSLCheckQtyReceived
	{
		readonly IApplicationDB appDB;
		
		
		public FTSLCheckQtyReceived(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? OperQtyComplete,
		decimal? OperQtyScrapped,
		decimal? OperQtyReceived,
		string Infobar) FTSLCheckQtyReceivedSp(string Job,
		int? Suffix,
		int? OperNum,
		decimal? OperQtyComplete,
		decimal? OperQtyScrapped,
		decimal? OperQtyReceived,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			QtyUnitNoNegType _OperQtyComplete = OperQtyComplete;
			QtyUnitNoNegType _OperQtyScrapped = OperQtyScrapped;
			QtyUnitNoNegType _OperQtyReceived = OperQtyReceived;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLCheckQtyReceivedSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperQtyComplete", _OperQtyComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperQtyScrapped", _OperQtyScrapped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperQtyReceived", _OperQtyReceived, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OperQtyComplete = _OperQtyComplete;
				OperQtyScrapped = _OperQtyScrapped;
				OperQtyReceived = _OperQtyReceived;
				Infobar = _Infobar;
				
				return (Severity, OperQtyComplete, OperQtyScrapped, OperQtyReceived, Infobar);
			}
		}
	}
}
