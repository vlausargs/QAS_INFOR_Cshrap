//PROJECT NAME: Finance
//CLASS NAME: ArpmtdGetInvAmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtdGetInvAmts : IArpmtdGetInvAmts
	{
		readonly IApplicationDB appDB;
		
		public ArpmtdGetInvAmts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PArpmtdForAmtApplied,
			decimal? PArpmtdForDiscAmt,
			decimal? PArpmtdDomAmtApplied,
			decimal? PArpmtdDomDiscAmt,
			decimal? PArpmtdExchRate,
			string Infobar) ArpmtdGetInvAmtsSp(
			string PArpmtdSite,
			string PArpmtdApplyCustNum,
			string PArpmtdInvNum,
			DateTime? PArpmtRecptDate,
			string PDerCustCurrCode,
			decimal? PForAmtRem,
			decimal? PArpmtdForAmtApplied,
			decimal? PArpmtdForDiscAmt,
			decimal? PArpmtdDomAmtApplied,
			decimal? PArpmtdDomDiscAmt,
			decimal? PArpmtdExchRate,
			string Infobar)
		{
			SiteType _PArpmtdSite = PArpmtdSite;
			CustNumType _PArpmtdApplyCustNum = PArpmtdApplyCustNum;
			InvNumType _PArpmtdInvNum = PArpmtdInvNum;
			DateType _PArpmtRecptDate = PArpmtRecptDate;
			CurrCodeType _PDerCustCurrCode = PDerCustCurrCode;
			AmountType _PForAmtRem = PForAmtRem;
			AmountType _PArpmtdForAmtApplied = PArpmtdForAmtApplied;
			AmountType _PArpmtdForDiscAmt = PArpmtdForDiscAmt;
			AmountType _PArpmtdDomAmtApplied = PArpmtdDomAmtApplied;
			AmountType _PArpmtdDomDiscAmt = PArpmtdDomDiscAmt;
			ExchRateType _PArpmtdExchRate = PArpmtdExchRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdGetInvAmtsSp";
				
				appDB.AddCommandParameter(cmd, "PArpmtdSite", _PArpmtdSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdApplyCustNum", _PArpmtdApplyCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdInvNum", _PArpmtdInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtRecptDate", _PArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDerCustCurrCode", _PDerCustCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmtRem", _PForAmtRem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdForAmtApplied", _PArpmtdForAmtApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdForDiscAmt", _PArpmtdForDiscAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDomAmtApplied", _PArpmtdDomAmtApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDomDiscAmt", _PArpmtdDomDiscAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdExchRate", _PArpmtdExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PArpmtdForAmtApplied = _PArpmtdForAmtApplied;
				PArpmtdForDiscAmt = _PArpmtdForDiscAmt;
				PArpmtdDomAmtApplied = _PArpmtdDomAmtApplied;
				PArpmtdDomDiscAmt = _PArpmtdDomDiscAmt;
				PArpmtdExchRate = _PArpmtdExchRate;
				Infobar = _Infobar;
				
				return (Severity, PArpmtdForAmtApplied, PArpmtdForDiscAmt, PArpmtdDomAmtApplied, PArpmtdDomDiscAmt, PArpmtdExchRate, Infobar);
			}
		}
	}
}
