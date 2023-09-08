//PROJECT NAME: Finance
//CLASS NAME: CalcActualBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class CalcActualBal : ICalcActualBal
	{
		readonly IApplicationDB appDB;
		
		public CalcActualBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Balance1,
			decimal? Balance2,
			decimal? Balance3,
			decimal? Balance4,
			decimal? Balance5,
			decimal? Balance6,
			decimal? Balance7,
			decimal? Balance8,
			decimal? Balance9,
			decimal? Balance10,
			decimal? Balance11,
			decimal? Balance12,
			decimal? Balance13,
			string Infobar) CalcActualBalSp(
			int? PFiscalYear,
			string PAcct,
			string PType,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PHierarchy,
			string PCurrCode,
			decimal? Balance1,
			decimal? Balance2,
			decimal? Balance3,
			decimal? Balance4,
			decimal? Balance5,
			decimal? Balance6,
			decimal? Balance7,
			decimal? Balance8,
			decimal? Balance9,
			decimal? Balance10,
			decimal? Balance11,
			decimal? Balance12,
			decimal? Balance13,
			string Infobar)
		{
			FiscalYearType _PFiscalYear = PFiscalYear;
			AcctType _PAcct = PAcct;
			ChartTypeType _PType = PType;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			HierarchyType _PHierarchy = PHierarchy;
			CurrCodeType _PCurrCode = PCurrCode;
			AmountType _Balance1 = Balance1;
			AmountType _Balance2 = Balance2;
			AmountType _Balance3 = Balance3;
			AmountType _Balance4 = Balance4;
			AmountType _Balance5 = Balance5;
			AmountType _Balance6 = Balance6;
			AmountType _Balance7 = Balance7;
			AmountType _Balance8 = Balance8;
			AmountType _Balance9 = Balance9;
			AmountType _Balance10 = Balance10;
			AmountType _Balance11 = Balance11;
			AmountType _Balance12 = Balance12;
			AmountType _Balance13 = Balance13;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcActualBalSp";
				
				appDB.AddCommandParameter(cmd, "PFiscalYear", _PFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHierarchy", _PHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Balance1", _Balance1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance2", _Balance2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance3", _Balance3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance4", _Balance4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance5", _Balance5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance6", _Balance6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance7", _Balance7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance8", _Balance8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance9", _Balance9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance10", _Balance10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance11", _Balance11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance12", _Balance12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance13", _Balance13, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Balance1 = _Balance1;
				Balance2 = _Balance2;
				Balance3 = _Balance3;
				Balance4 = _Balance4;
				Balance5 = _Balance5;
				Balance6 = _Balance6;
				Balance7 = _Balance7;
				Balance8 = _Balance8;
				Balance9 = _Balance9;
				Balance10 = _Balance10;
				Balance11 = _Balance11;
				Balance12 = _Balance12;
				Balance13 = _Balance13;
				Infobar = _Infobar;
				
				return (Severity, Balance1, Balance2, Balance3, Balance4, Balance5, Balance6, Balance7, Balance8, Balance9, Balance10, Balance11, Balance12, Balance13, Infobar);
			}
		}
	}
}
