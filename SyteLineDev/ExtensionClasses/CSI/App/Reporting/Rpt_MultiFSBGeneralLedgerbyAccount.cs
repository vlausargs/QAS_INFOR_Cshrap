//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerbyAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBGeneralLedgerbyAccount : IRpt_MultiFSBGeneralLedgerbyAccount
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_MultiFSBGeneralLedgerbyAccount(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBGeneralLedgerbyAccountSp(DateTime? SPerDate = null,
		DateTime? EPerDate = null,
		int? ShowAllTrx = null,
		string SortByTrx = null,
		string SecondSortBy = null,
		int? ShowDetail = null,
		int? AnalyticalLedger = null,
		string ChartType = null,
		string SAcct = null,
		string EAcct = null,
		string SiteGroup = null,
		int? SPerDateOffset = null,
		int? EPerDateOffset = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		string PSAcctUnit1 = null,
		string PEAcctUnit1 = null,
		string PSAcctUnit2 = null,
		string PEAcctUnit2 = null,
		string PSAcctUnit3 = null,
		string PEAcctUnit3 = null,
		string PSAcctUnit4 = null,
		string PEAcctUnit4 = null,
		string FirstUnitSort = null,
		string SecondUnitSort = null,
		string ThirdUnitSort = null,
		string FourthUnitSort = null,
		string FSBName = null,
		string pSite = null)
		{
			DateType _SPerDate = SPerDate;
			DateType _EPerDate = EPerDate;
			FlagNyType _ShowAllTrx = ShowAllTrx;
			StringType _SortByTrx = SortByTrx;
			StringType _SecondSortBy = SecondSortBy;
			FlagNyType _ShowDetail = ShowDetail;
			FlagNyType _AnalyticalLedger = AnalyticalLedger;
			StringType _ChartType = ChartType;
			AcctType _SAcct = SAcct;
			AcctType _EAcct = EAcct;
			SiteGroupType _SiteGroup = SiteGroup;
			DateOffsetType _SPerDateOffset = SPerDateOffset;
			DateOffsetType _EPerDateOffset = EPerDateOffset;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			UnitCode1Type _PSAcctUnit1 = PSAcctUnit1;
			UnitCode1Type _PEAcctUnit1 = PEAcctUnit1;
			UnitCode2Type _PSAcctUnit2 = PSAcctUnit2;
			UnitCode2Type _PEAcctUnit2 = PEAcctUnit2;
			UnitCode3Type _PSAcctUnit3 = PSAcctUnit3;
			UnitCode3Type _PEAcctUnit3 = PEAcctUnit3;
			UnitCode4Type _PSAcctUnit4 = PSAcctUnit4;
			UnitCode4Type _PEAcctUnit4 = PEAcctUnit4;
			StringType _FirstUnitSort = FirstUnitSort;
			StringType _SecondUnitSort = SecondUnitSort;
			StringType _ThirdUnitSort = ThirdUnitSort;
			StringType _FourthUnitSort = FourthUnitSort;
			FSBNameType _FSBName = FSBName;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MultiFSBGeneralLedgerbyAccountSp";
				
				appDB.AddCommandParameter(cmd, "SPerDate", _SPerDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPerDate", _EPerDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowAllTrx", _ShowAllTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortByTrx", _SortByTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SecondSortBy", _SecondSortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalyticalLedger", _AnalyticalLedger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartType", _ChartType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcct", _SAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcct", _EAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPerDateOffset", _SPerDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPerDateOffset", _EPerDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSAcctUnit1", _PSAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEAcctUnit1", _PEAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSAcctUnit2", _PSAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEAcctUnit2", _PEAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSAcctUnit3", _PSAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEAcctUnit3", _PEAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSAcctUnit4", _PSAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEAcctUnit4", _PEAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstUnitSort", _FirstUnitSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SecondUnitSort", _SecondUnitSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ThirdUnitSort", _ThirdUnitSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FourthUnitSort", _FourthUnitSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
