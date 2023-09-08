//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectPurchaseOrderCommitments2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjectPurchaseOrderCommitments2 : IRpt_ProjectPurchaseOrderCommitments2
	{
		readonly IApplicationDB appDB;
		
		public Rpt_ProjectPurchaseOrderCommitments2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_ProjectPurchaseOrderCommitments2Sp(
			string Job,
			int? Suffix,
			decimal? Qty,
			string ProjNum,
			int? TaskNum,
			string TPoitemStat,
			int? PrintCost)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			QtyTotlType _Qty = Qty;
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			LongListType _TPoitemStat = TPoitemStat;
			ListYesNoType _PrintCost = PrintCost;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjectPurchaseOrderCommitments2Sp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPoitemStat", _TPoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
