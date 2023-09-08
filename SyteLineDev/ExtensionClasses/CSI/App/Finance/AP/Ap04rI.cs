//PROJECT NAME: Finance
//CLASS NAME: Ap04RI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AP
{
	public class Ap04RI : IAp04RI
	{
		readonly IApplicationDB appDB;
		
		public Ap04RI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TcAmtDisplay,
			decimal? TcAmtTotDr,
			decimal? TcAmtTotCr,
			decimal? DomTcAmtTotDr,
			decimal? DomTcAmtTotCr,
			decimal? DomTcAmtDisplay,
			string AcctTxt,
			string InfoBar) Ap04RISP(
			int? PGainLoss,
			string VendorCurrCode,
			string CurrparmsCurrCode,
			decimal? PExchRate,
			decimal? PInvAmt,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			decimal? TcAmtDisplay,
			decimal? TcAmtTotDr,
			decimal? TcAmtTotCr,
			decimal? DomTcAmtTotDr,
			decimal? DomTcAmtTotCr,
			decimal? DomTcAmtDisplay,
			string AcctTxt,
			string InfoBar,
			int? PCancellation = 0)
		{
			IntType _PGainLoss = PGainLoss;
			CurrCodeType _VendorCurrCode = VendorCurrCode;
			CurrCodeType _CurrparmsCurrCode = CurrparmsCurrCode;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PInvAmt = PInvAmt;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			AmountType _TcAmtDisplay = TcAmtDisplay;
			AmountType _TcAmtTotDr = TcAmtTotDr;
			AmountType _TcAmtTotCr = TcAmtTotCr;
			AmountType _DomTcAmtTotDr = DomTcAmtTotDr;
			AmountType _DomTcAmtTotCr = DomTcAmtTotCr;
			AmountType _DomTcAmtDisplay = DomTcAmtDisplay;
			DescriptionType _AcctTxt = AcctTxt;
			InfobarType _InfoBar = InfoBar;
			ListYesNoType _PCancellation = PCancellation;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Ap04RISP";
				
				appDB.AddCommandParameter(cmd, "PGainLoss", _PGainLoss, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorCurrCode", _VendorCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrparmsCurrCode", _CurrparmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvAmt", _PInvAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcAmtDisplay", _TcAmtDisplay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcAmtTotDr", _TcAmtTotDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcAmtTotCr", _TcAmtTotCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomTcAmtTotDr", _DomTcAmtTotDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomTcAmtTotCr", _DomTcAmtTotCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomTcAmtDisplay", _DomTcAmtDisplay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctTxt", _AcctTxt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCancellation", _PCancellation, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TcAmtDisplay = _TcAmtDisplay;
				TcAmtTotDr = _TcAmtTotDr;
				TcAmtTotCr = _TcAmtTotCr;
				DomTcAmtTotDr = _DomTcAmtTotDr;
				DomTcAmtTotCr = _DomTcAmtTotCr;
				DomTcAmtDisplay = _DomTcAmtDisplay;
				AcctTxt = _AcctTxt;
				InfoBar = _InfoBar;
				
				return (Severity, TcAmtDisplay, TcAmtTotDr, TcAmtTotCr, DomTcAmtTotDr, DomTcAmtTotCr, DomTcAmtDisplay, AcctTxt, InfoBar);
			}
		}
	}
}
