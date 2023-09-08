//PROJECT NAME: Finance
//CLASS NAME: ArpmtCalcCheckAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtCalcCheckAmt : IArpmtCalcCheckAmt
	{
		readonly IApplicationDB appDB;
		
		public ArpmtCalcCheckAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? POutCheckAmt,
			string Infobar) ArpmtCalcCheckAmtSp(
			decimal? PExchRate,
			decimal? PInCheckAmt,
			string PCustCurr,
			DateTime? PRecptDate,
			int? PToCustomer,
			decimal? POutCheckAmt,
			string Infobar)
		{
			ExchRateType _PExchRate = PExchRate;
			AmountType _PInCheckAmt = PInCheckAmt;
			CurrCodeType _PCustCurr = PCustCurr;
			DateType _PRecptDate = PRecptDate;
			FlagNyType _PToCustomer = PToCustomer;
			AmountType _POutCheckAmt = POutCheckAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtCalcCheckAmtSp";
				
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInCheckAmt", _PInCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustCurr", _PCustCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCustomer", _PToCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POutCheckAmt", _POutCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POutCheckAmt = _POutCheckAmt;
				Infobar = _Infobar;
				
				return (Severity, POutCheckAmt, Infobar);
			}
		}
	}
}
