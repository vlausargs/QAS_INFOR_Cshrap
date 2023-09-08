//PROJECT NAME: Finance
//CLASS NAME: CalcBalSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class CalcBalSetVars : ICalcBalSetVars
	{
		readonly IApplicationDB appDB;
		
		public CalcBalSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Balance,
			DateTime? SLedger,
			DateTime? ELedger,
			int? FirstTimeRun,
			string Infobar) CalcBalSetVarsSp(
			string TMethod,
			int? TUse,
			int? TTrans,
			string PCurrCode,
			int? PIncome,
			DateTime? PertotPerStart,
			DateTime? PertotPerEnd,
			decimal? PertotAmt,
			decimal? PertotSummary,
			decimal? Balance,
			DateTime? SLedger,
			DateTime? ELedger,
			int? FirstTimeRun,
			string Infobar,
			string pSite = null)
		{
			CurrTransMethodType _TMethod = TMethod;
			ListBuySellType _TUse = TUse;
			FlagNyType _TTrans = TTrans;
			CurrCodeType _PCurrCode = PCurrCode;
			FlagNyType _PIncome = PIncome;
			DateType _PertotPerStart = PertotPerStart;
			DateType _PertotPerEnd = PertotPerEnd;
			AmountType _PertotAmt = PertotAmt;
			AmountType _PertotSummary = PertotSummary;
			GenericDecimalType _Balance = Balance;
			CurrentDateType _SLedger = SLedger;
			CurrentDateType _ELedger = ELedger;
			FlagNyType _FirstTimeRun = FirstTimeRun;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcBalSetVarsSp";
				
				appDB.AddCommandParameter(cmd, "TMethod", _TMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUse", _TUse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTrans", _TTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIncome", _PIncome, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PertotPerStart", _PertotPerStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PertotPerEnd", _PertotPerEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PertotAmt", _PertotAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PertotSummary", _PertotSummary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Balance", _Balance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SLedger", _SLedger, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ELedger", _ELedger, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FirstTimeRun", _FirstTimeRun, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Balance = _Balance;
				SLedger = _SLedger;
				ELedger = _ELedger;
				FirstTimeRun = _FirstTimeRun;
				Infobar = _Infobar;
				
				return (Severity, Balance, SLedger, ELedger, FirstTimeRun, Infobar);
			}
		}
	}
}
