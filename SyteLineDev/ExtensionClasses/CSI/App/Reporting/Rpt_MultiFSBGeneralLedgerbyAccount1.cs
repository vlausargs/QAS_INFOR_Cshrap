//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerbyAccount1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBGeneralLedgerbyAccount1 : IRpt_MultiFSBGeneralLedgerbyAccount1
	{
		readonly IApplicationDB appDB;
		
		public Rpt_MultiFSBGeneralLedgerbyAccount1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_MultiFSBGeneralLedgerbyAccount1Sp(
			int? PAnalyticalLedger,
			string PCurSiteGroup,
			string PCurSite,
			DateTime? PSPerDate,
			DateTime? PEPerDate,
			int? PShowAllTrx,
			int? PShowDetail,
			string PChartType,
			string PSAcct,
			string PEAcct,
			string PSAcctUnit1,
			string PEAcctUnit1,
			string PSAcctUnit2,
			string PEAcctUnit2,
			string PSAcctUnit3,
			string PEAcctUnit3,
			string PSAcctUnit4,
			string PEAcctUnit4,
			int? PShowInternal = null,
			int? PShowExternal = null,
			string FirstUnitSort = null,
			string SecondUnitSort = null,
			string ThirdUnitSort = null,
			string FourthUnitSort = null,
			string FSBName = null)
		{
			FlagNyType _PAnalyticalLedger = PAnalyticalLedger;
			SiteGroupType _PCurSiteGroup = PCurSiteGroup;
			SiteType _PCurSite = PCurSite;
			DateType _PSPerDate = PSPerDate;
			DateType _PEPerDate = PEPerDate;
			FlagNyType _PShowAllTrx = PShowAllTrx;
			FlagNyType _PShowDetail = PShowDetail;
			StringType _PChartType = PChartType;
			AcctType _PSAcct = PSAcct;
			AcctType _PEAcct = PEAcct;
			UnitCode1Type _PSAcctUnit1 = PSAcctUnit1;
			UnitCode1Type _PEAcctUnit1 = PEAcctUnit1;
			UnitCode2Type _PSAcctUnit2 = PSAcctUnit2;
			UnitCode2Type _PEAcctUnit2 = PEAcctUnit2;
			UnitCode3Type _PSAcctUnit3 = PSAcctUnit3;
			UnitCode3Type _PEAcctUnit3 = PEAcctUnit3;
			UnitCode4Type _PSAcctUnit4 = PSAcctUnit4;
			UnitCode4Type _PEAcctUnit4 = PEAcctUnit4;
			FlagNyType _PShowInternal = PShowInternal;
			FlagNyType _PShowExternal = PShowExternal;
			StringType _FirstUnitSort = FirstUnitSort;
			StringType _SecondUnitSort = SecondUnitSort;
			StringType _ThirdUnitSort = ThirdUnitSort;
			StringType _FourthUnitSort = FourthUnitSort;
			FSBNameType _FSBName = FSBName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MultiFSBGeneralLedgerbyAccount1Sp";
				
				appDB.AddCommandParameter(cmd, "PAnalyticalLedger", _PAnalyticalLedger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurSiteGroup", _PCurSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurSite", _PCurSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSPerDate", _PSPerDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEPerDate", _PEPerDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowAllTrx", _PShowAllTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowDetail", _PShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PChartType", _PChartType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSAcct", _PSAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEAcct", _PEAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSAcctUnit1", _PSAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEAcctUnit1", _PEAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSAcctUnit2", _PSAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEAcctUnit2", _PEAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSAcctUnit3", _PSAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEAcctUnit3", _PEAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSAcctUnit4", _PSAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEAcctUnit4", _PEAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowInternal", _PShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowExternal", _PShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstUnitSort", _FirstUnitSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SecondUnitSort", _SecondUnitSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ThirdUnitSort", _ThirdUnitSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FourthUnitSort", _FourthUnitSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
