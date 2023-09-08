//PROJECT NAME: Production
//CLASS NAME: RevMsInit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class RevMsInit : IRevMsInit
	{
		readonly IApplicationDB appDB;
		
		
		public RevMsInit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RevCalcMethod,
		decimal? RevCalcPct,
		decimal? RevCalcAmt,
		string CostCalcMethod,
		decimal? CostCalcPct,
		decimal? CostCalcAmt) RevMsInitSp(string ProjNum,
		string RevCalcMethod,
		decimal? RevCalcPct,
		decimal? RevCalcAmt,
		string CostCalcMethod,
		decimal? CostCalcPct,
		decimal? CostCalcAmt)
		{
			ProjNumType _ProjNum = ProjNum;
			ProjRevCalcMethodType _RevCalcMethod = RevCalcMethod;
			ProjCalcPercentType _RevCalcPct = RevCalcPct;
			ProjCalcAmountType _RevCalcAmt = RevCalcAmt;
			ProjCostCalcMethodType _CostCalcMethod = CostCalcMethod;
			ProjCalcPercentType _CostCalcPct = CostCalcPct;
			ProjCalcAmountType _CostCalcAmt = CostCalcAmt;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RevMsInitSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevCalcMethod", _RevCalcMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevCalcPct", _RevCalcPct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevCalcAmt", _RevCalcAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostCalcMethod", _CostCalcMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostCalcPct", _CostCalcPct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostCalcAmt", _CostCalcAmt, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RevCalcMethod = _RevCalcMethod;
				RevCalcPct = _RevCalcPct;
				RevCalcAmt = _RevCalcAmt;
				CostCalcMethod = _CostCalcMethod;
				CostCalcPct = _CostCalcPct;
				CostCalcAmt = _CostCalcAmt;
				
				return (Severity, RevCalcMethod, RevCalcPct, RevCalcAmt, CostCalcMethod, CostCalcPct, CostCalcAmt);
			}
		}
	}
}
