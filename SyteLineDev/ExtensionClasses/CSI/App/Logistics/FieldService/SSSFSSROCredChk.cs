//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROCredChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROCredChk : ISSSFSSROCredChk
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROCredChk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSROCredChkSp(
			string CustNum = null,
			decimal? Adjust = 0,
			int? AlwaysWarn = 0,
			int? AbortCredCk = 0,
			int? OrderChg = 0,
			string SRONum = null,
			int? SroLine = null,
			int? SroOper = null,
			int? CreditHold = null,
			int? NoMsg = 0,
			int? RollbackOnError = 0,
			string Infobar = null)
		{
			CustNumType _CustNum = CustNum;
			AmountType _Adjust = Adjust;
			Flag _AlwaysWarn = AlwaysWarn;
			Flag _AbortCredCk = AbortCredCk;
			Flag _OrderChg = OrderChg;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			Flag _CreditHold = CreditHold;
			Flag _NoMsg = NoMsg;
			Flag _RollbackOnError = RollbackOnError;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROCredChkSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Adjust", _Adjust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlwaysWarn", _AlwaysWarn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AbortCredCk", _AbortCredCk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderChg", _OrderChg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHold", _CreditHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoMsg", _NoMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RollbackOnError", _RollbackOnError, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
