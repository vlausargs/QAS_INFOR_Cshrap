//PROJECT NAME: Reporting
//CLASS NAME: WBCanArAgingBucketParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.CriticalNumber
{
	public class WBCanArAgingBucketParms : IWBCanArAgingBucketParms
	{
		readonly IApplicationDB appDB;
		
		public WBCanArAgingBucketParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Days,
			decimal? TotGoal,
			decimal? TotAlert,
			decimal? PctGoal,
			decimal? PctAlert,
			int? ShowIndTot,
			int? ShowIndPct) WBCanArAgingBucketParmsSp(
			int? KPINum,
			int? Index,
			int? Days,
			decimal? TotGoal,
			decimal? TotAlert,
			decimal? PctGoal,
			decimal? PctAlert,
			int? ShowIndTot,
			int? ShowIndPct)
		{
			WBKPINumType _KPINum = KPINum;
			IntType _Index = Index;
			IntType _Days = Days;
			AmountType _TotGoal = TotGoal;
			AmountType _TotAlert = TotAlert;
			AmountType _PctGoal = PctGoal;
			AmountType _PctAlert = PctAlert;
			ListYesNoType _ShowIndTot = ShowIndTot;
			ListYesNoType _ShowIndPct = ShowIndPct;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBCanArAgingBucketParmsSp";
				
				appDB.AddCommandParameter(cmd, "KPINum", _KPINum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Index", _Index, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Days", _Days, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotGoal", _TotGoal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotAlert", _TotAlert, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctGoal", _PctGoal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctAlert", _PctAlert, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndTot", _ShowIndTot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndPct", _ShowIndPct, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Days = _Days;
				TotGoal = _TotGoal;
				TotAlert = _TotAlert;
				PctGoal = _PctGoal;
				PctAlert = _PctAlert;
				ShowIndTot = _ShowIndTot;
				ShowIndPct = _ShowIndPct;
				
				return (Severity, Days, TotGoal, TotAlert, PctGoal, PctAlert, ShowIndTot, ShowIndPct);
			}
		}
	}
}
