//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SortMethods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_SortMethods : IRpt_SortMethods
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SortMethods(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SortMethodsSp(string ReportID = null,
		string ReportType = "M",
		string SiteGroup = null,
		int? AcctDetail = 0,
		int? Unit1Detail = 0,
		int? Unit2Detail = 0,
		int? Unit3Detail = 0,
		int? Unit4Detail = 0,
		string SAcctUnit1 = null,
		string SAcctUnit2 = null,
		string SAcctUnit3 = null,
		string SAcctUnit4 = null,
		string EAcctUnit1 = null,
		string EAcctUnit2 = null,
		string EAcctUnit3 = null,
		string EAcctUnit4 = null,
		int? AcctSort__1 = 0,
		int? AcctSort__2 = 0,
		int? AcctSort__3 = 0,
		int? AcctSort__4 = 0,
		int? AcctSort__5 = 0,
		string pSite = null,
		string BGUser = null)
		{
			RptIdType _ReportID = ReportID;
			ShortDescType _ReportType = ReportType;
			SiteGroupType _SiteGroup = SiteGroup;
			ListYesNoType _AcctDetail = AcctDetail;
			ListYesNoType _Unit1Detail = Unit1Detail;
			ListYesNoType _Unit2Detail = Unit2Detail;
			ListYesNoType _Unit3Detail = Unit3Detail;
			ListYesNoType _Unit4Detail = Unit4Detail;
			UnitCode1Type _SAcctUnit1 = SAcctUnit1;
			UnitCode2Type _SAcctUnit2 = SAcctUnit2;
			UnitCode3Type _SAcctUnit3 = SAcctUnit3;
			UnitCode4Type _SAcctUnit4 = SAcctUnit4;
			UnitCode1Type _EAcctUnit1 = EAcctUnit1;
			UnitCode2Type _EAcctUnit2 = EAcctUnit2;
			UnitCode3Type _EAcctUnit3 = EAcctUnit3;
			UnitCode4Type _EAcctUnit4 = EAcctUnit4;
			SortMethodType _AcctSort__1 = AcctSort__1;
			SortMethodType _AcctSort__2 = AcctSort__2;
			SortMethodType _AcctSort__3 = AcctSort__3;
			SortMethodType _AcctSort__4 = AcctSort__4;
			SortMethodType _AcctSort__5 = AcctSort__5;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SortMethodsSp";
				
				appDB.AddCommandParameter(cmd, "ReportID", _ReportID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportType", _ReportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctDetail", _AcctDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit1Detail", _Unit1Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit2Detail", _Unit2Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit3Detail", _Unit3Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit4Detail", _Unit4Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit1", _SAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit2", _SAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit3", _SAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit4", _SAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit1", _EAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit2", _EAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit3", _EAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit4", _EAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctSort##1", _AcctSort__1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctSort##2", _AcctSort__2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctSort##3", _AcctSort__3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctSort##4", _AcctSort__4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctSort##5", _AcctSort__5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
