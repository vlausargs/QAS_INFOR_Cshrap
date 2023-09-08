//PROJECT NAME: Data
//CLASS NAME: CalDomDrCrAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalDomDrCrAmt : ICalDomDrCrAmt
	{
		readonly IApplicationDB appDB;
		
		public CalDomDrCrAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TcAmtDisplay,
			decimal? DomTcAmtTotDr,
			decimal? DomTcAmtTotCr,
			decimal? DomTcAmtDisplay,
			string AcctTxt,
			string InfoBar,
			decimal? TcAmtTotDr,
			decimal? TcAmtTotCr) CalDomDrCrAmtSp(
			int? PGainLoss,
			string AptrxCurrCode,
			string CurrparmsCurrCode,
			decimal? PExchRate,
			decimal? PInvAmt,
			string PAcct,
			decimal? TcAmtDisplay,
			decimal? DomTcAmtTotDr,
			decimal? DomTcAmtTotCr,
			decimal? DomTcAmtDisplay,
			string AcctTxt,
			string InfoBar,
			decimal? TcAmtTotDr,
			decimal? TcAmtTotCr,
			int? InsTemp = 0,
			string PAcctUnit1 = null,
			string PAcctUnit2 = null,
			string PAcctUnit3 = null,
			string PAcctUnit4 = null)
		{
			FlagNyType _PGainLoss = PGainLoss;
			CurrCodeType _AptrxCurrCode = AptrxCurrCode;
			CurrCodeType _CurrparmsCurrCode = CurrparmsCurrCode;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PInvAmt = PInvAmt;
			AcctType _PAcct = PAcct;
			AmountType _TcAmtDisplay = TcAmtDisplay;
			AmountType _DomTcAmtTotDr = DomTcAmtTotDr;
			AmountType _DomTcAmtTotCr = DomTcAmtTotCr;
			AmountType _DomTcAmtDisplay = DomTcAmtDisplay;
			DescriptionType _AcctTxt = AcctTxt;
			InfobarType _InfoBar = InfoBar;
			AmountType _TcAmtTotDr = TcAmtTotDr;
			AmountType _TcAmtTotCr = TcAmtTotCr;
			FlagNyType _InsTemp = InsTemp;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalDomDrCrAmtSp";
				
				appDB.AddCommandParameter(cmd, "PGainLoss", _PGainLoss, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxCurrCode", _AptrxCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrparmsCurrCode", _CurrparmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvAmt", _PInvAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcAmtDisplay", _TcAmtDisplay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomTcAmtTotDr", _DomTcAmtTotDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomTcAmtTotCr", _DomTcAmtTotCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomTcAmtDisplay", _DomTcAmtDisplay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctTxt", _AcctTxt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcAmtTotDr", _TcAmtTotDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcAmtTotCr", _TcAmtTotCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InsTemp", _InsTemp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TcAmtDisplay = _TcAmtDisplay;
				DomTcAmtTotDr = _DomTcAmtTotDr;
				DomTcAmtTotCr = _DomTcAmtTotCr;
				DomTcAmtDisplay = _DomTcAmtDisplay;
				AcctTxt = _AcctTxt;
				InfoBar = _InfoBar;
				TcAmtTotDr = _TcAmtTotDr;
				TcAmtTotCr = _TcAmtTotCr;
				
				return (Severity, TcAmtDisplay, DomTcAmtTotDr, DomTcAmtTotCr, DomTcAmtDisplay, AcctTxt, InfoBar, TcAmtTotDr, TcAmtTotCr);
			}
		}
	}
}
