//PROJECT NAME: Logistics
//CLASS NAME: AppmtCalcCheckAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtCalcCheckAmt : IAppmtCalcCheckAmt
	{
		readonly IApplicationDB appDB;
		
		
		public AppmtCalcCheckAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PExchRate,
		decimal? POutCheckAmt,
		string Infobar) AppmtCalcCheckAmtSp(decimal? PExchRate,
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
				cmd.CommandText = "AppmtCalcCheckAmtSp";
				
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInCheckAmt", _PInCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustCurr", _PCustCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCustomer", _PToCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POutCheckAmt", _POutCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PExchRate = _PExchRate;
				POutCheckAmt = _POutCheckAmt;
				Infobar = _Infobar;
				
				return (Severity, PExchRate, POutCheckAmt, Infobar);
			}
		}
	}
}
