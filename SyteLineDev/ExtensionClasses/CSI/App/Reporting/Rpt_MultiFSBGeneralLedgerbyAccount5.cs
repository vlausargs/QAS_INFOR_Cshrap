//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerbyAccount5.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBGeneralLedgerbyAccount5 : IRpt_MultiFSBGeneralLedgerbyAccount5
	{
		readonly IApplicationDB appDB;
		
		public Rpt_MultiFSBGeneralLedgerbyAccount5(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PReportSet3RowPointer,
			int? PTtUnitRowPointer,
			string PTtUnitAcctUnit1,
			string PTtUnitAcctUnit2,
			string PTtUnitAcctUnit3,
			string PTtUnitAcctUnit4,
			string PTOldUc,
			decimal? PTcTotUcDr,
			decimal? PTcTotUcCr,
			decimal? PTcTotUcEnd,
			decimal? PTcTotUcBeg) Rpt_MultiFSBGeneralLedgerbyAccount5Sp(
			Guid? PGLRowPointer,
			int? PReportSet3RowPointer,
			string PSite,
			int? PTtUnitRowPointer,
			string PTtUnitAcctUnit1,
			string PTtUnitAcctUnit2,
			string PTtUnitAcctUnit3,
			string PTtUnitAcctUnit4,
			string PSortByTrx,
			int? PIsSortByUc,
			int? PIsSubUc,
			string PTOldUc,
			decimal? PTcTotUcDr,
			decimal? PTcTotUcCr,
			decimal? PTcTotUcEnd,
			decimal? PTcTotUcBeg,
			int? PNumHier,
			string PEntList,
			DateTime? PSDate,
			DateTime? PEDate,
			string PChartAcct,
			string PChartType,
			string PSort,
			int? PSortMethod,
			string PCurrCode,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			decimal? PTcTotAcctBeg,
			string FSBName = null)
		{
			RowPointerType _PGLRowPointer = PGLRowPointer;
			IntType _PReportSet3RowPointer = PReportSet3RowPointer;
			SiteType _PSite = PSite;
			IntType _PTtUnitRowPointer = PTtUnitRowPointer;
			UnitCode1Type _PTtUnitAcctUnit1 = PTtUnitAcctUnit1;
			UnitCode1Type _PTtUnitAcctUnit2 = PTtUnitAcctUnit2;
			UnitCode1Type _PTtUnitAcctUnit3 = PTtUnitAcctUnit3;
			UnitCode1Type _PTtUnitAcctUnit4 = PTtUnitAcctUnit4;
			StringType _PSortByTrx = PSortByTrx;
			FlagNyType _PIsSortByUc = PIsSortByUc;
			FlagNyType _PIsSubUc = PIsSubUc;
			UnitCode1Type _PTOldUc = PTOldUc;
			AmountType _PTcTotUcDr = PTcTotUcDr;
			AmountType _PTcTotUcCr = PTcTotUcCr;
			AmountType _PTcTotUcEnd = PTcTotUcEnd;
			AmountType _PTcTotUcBeg = PTcTotUcBeg;
			GenericNoType _PNumHier = PNumHier;
			LongListType _PEntList = PEntList;
			DateType _PSDate = PSDate;
			DateType _PEDate = PEDate;
			AcctType _PChartAcct = PChartAcct;
			StringType _PChartType = PChartType;
			LongListType _PSort = PSort;
			SortMethodType _PSortMethod = PSortMethod;
			CurrCodeType _PCurrCode = PCurrCode;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode1Type _PAcctUnit2 = PAcctUnit2;
			UnitCode1Type _PAcctUnit3 = PAcctUnit3;
			UnitCode1Type _PAcctUnit4 = PAcctUnit4;
			AmountType _PTcTotAcctBeg = PTcTotAcctBeg;
			FSBNameType _FSBName = FSBName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MultiFSBGeneralLedgerbyAccount5Sp";
				
				appDB.AddCommandParameter(cmd, "PGLRowPointer", _PGLRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReportSet3RowPointer", _PReportSet3RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTtUnitRowPointer", _PTtUnitRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTtUnitAcctUnit1", _PTtUnitAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTtUnitAcctUnit2", _PTtUnitAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTtUnitAcctUnit3", _PTtUnitAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTtUnitAcctUnit4", _PTtUnitAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSortByTrx", _PSortByTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIsSortByUc", _PIsSortByUc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIsSubUc", _PIsSubUc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTOldUc", _PTOldUc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTcTotUcDr", _PTcTotUcDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTcTotUcCr", _PTcTotUcCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTcTotUcEnd", _PTcTotUcEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTcTotUcBeg", _PTcTotUcBeg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNumHier", _PNumHier, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEntList", _PEntList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSDate", _PSDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEDate", _PEDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PChartAcct", _PChartAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PChartType", _PChartType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSort", _PSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortMethod", _PSortMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcTotAcctBeg", _PTcTotAcctBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PReportSet3RowPointer = _PReportSet3RowPointer;
				PTtUnitRowPointer = _PTtUnitRowPointer;
				PTtUnitAcctUnit1 = _PTtUnitAcctUnit1;
				PTtUnitAcctUnit2 = _PTtUnitAcctUnit2;
				PTtUnitAcctUnit3 = _PTtUnitAcctUnit3;
				PTtUnitAcctUnit4 = _PTtUnitAcctUnit4;
				PTOldUc = _PTOldUc;
				PTcTotUcDr = _PTcTotUcDr;
				PTcTotUcCr = _PTcTotUcCr;
				PTcTotUcEnd = _PTcTotUcEnd;
				PTcTotUcBeg = _PTcTotUcBeg;
				
				return (Severity, PReportSet3RowPointer, PTtUnitRowPointer, PTtUnitAcctUnit1, PTtUnitAcctUnit2, PTtUnitAcctUnit3, PTtUnitAcctUnit4, PTOldUc, PTcTotUcDr, PTcTotUcCr, PTcTotUcEnd, PTcTotUcBeg);
			}
		}
	}
}
