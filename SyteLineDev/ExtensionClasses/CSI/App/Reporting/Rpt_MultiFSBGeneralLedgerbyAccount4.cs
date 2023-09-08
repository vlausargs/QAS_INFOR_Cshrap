//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerbyAccount4.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBGeneralLedgerbyAccount4 : IRpt_MultiFSBGeneralLedgerbyAccount4
	{
		readonly IApplicationDB appDB;
		
		public Rpt_MultiFSBGeneralLedgerbyAccount4(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_MultiFSBGeneralLedgerbyAccount4Sp(
			int? PTabType,
			string PSite,
			string PHierarchy,
			string PSort,
			int? PSortMethod,
			string PChartAcct,
			string SAcctUnit1,
			string EAcctUnit1,
			string SAcctUnit2,
			string EAcctUnit2,
			string SAcctUnit3,
			string EAcctUnit3,
			string SAcctUnit4,
			string EAcctUnit4,
			string FSBName = null)
		{
			ByteType _PTabType = PTabType;
			SiteType _PSite = PSite;
			HierarchyType _PHierarchy = PHierarchy;
			LongListType _PSort = PSort;
			SortMethodType _PSortMethod = PSortMethod;
			AcctType _PChartAcct = PChartAcct;
			UnitCode1Type _SAcctUnit1 = SAcctUnit1;
			UnitCode1Type _EAcctUnit1 = EAcctUnit1;
			UnitCode2Type _SAcctUnit2 = SAcctUnit2;
			UnitCode2Type _EAcctUnit2 = EAcctUnit2;
			UnitCode3Type _SAcctUnit3 = SAcctUnit3;
			UnitCode3Type _EAcctUnit3 = EAcctUnit3;
			UnitCode4Type _SAcctUnit4 = SAcctUnit4;
			UnitCode4Type _EAcctUnit4 = EAcctUnit4;
			FSBNameType _FSBName = FSBName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MultiFSBGeneralLedgerbyAccount4Sp";
				
				appDB.AddCommandParameter(cmd, "PTabType", _PTabType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHierarchy", _PHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSort", _PSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortMethod", _PSortMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PChartAcct", _PChartAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit1", _SAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit1", _EAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit2", _SAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit2", _EAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit3", _SAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit3", _EAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit4", _SAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit4", _EAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
