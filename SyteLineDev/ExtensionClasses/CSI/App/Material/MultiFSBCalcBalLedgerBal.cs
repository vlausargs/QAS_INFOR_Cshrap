//PROJECT NAME: Finance
//CLASS NAME: MultiFSBCalcBalLedgerBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBCalcBalLedgerBal : IMultiFSBCalcBalLedgerBal
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBCalcBalLedgerBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Balance,
			string Infobar) MultiFSBCalcBalLedgerBalSp(
			string TMethod,
			int? TUse,
			DateTime? PStartDate,
			DateTime? PEndDate,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PType,
			string PBalType,
			int? THasGoodPerSort,
			int? UseU1,
			int? UseU2,
			int? UseU3,
			int? UseU4,
			int? TTrans,
			string PCurrCode,
			int? PIncome,
			decimal? Balance,
			string Infobar,
			string pSite = null,
			string FSBName = null)
		{
			CurrTransMethodType _TMethod = TMethod;
			ListBuySellType _TUse = TUse;
			CurrentDateType _PStartDate = PStartDate;
			CurrentDateType _PEndDate = PEndDate;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			ChartTypeType _PType = PType;
			GlrptlBalTypeType _PBalType = PBalType;
			FlagNyType _THasGoodPerSort = THasGoodPerSort;
			FlagNyType _UseU1 = UseU1;
			FlagNyType _UseU2 = UseU2;
			FlagNyType _UseU3 = UseU3;
			FlagNyType _UseU4 = UseU4;
			FlagNyType _TTrans = TTrans;
			CurrCodeType _PCurrCode = PCurrCode;
			FlagNyType _PIncome = PIncome;
			GenericDecimalType _Balance = Balance;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
			FSBNameType _FSBName = FSBName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBCalcBalLedgerBalSp";
				
				appDB.AddCommandParameter(cmd, "TMethod", _TMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUse", _TUse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBalType", _PBalType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "THasGoodPerSort", _THasGoodPerSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseU1", _UseU1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseU2", _UseU2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseU3", _UseU3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseU4", _UseU4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTrans", _TTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIncome", _PIncome, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Balance", _Balance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Balance = _Balance;
				Infobar = _Infobar;
				
				return (Severity, Balance, Infobar);
			}
		}
	}
}
