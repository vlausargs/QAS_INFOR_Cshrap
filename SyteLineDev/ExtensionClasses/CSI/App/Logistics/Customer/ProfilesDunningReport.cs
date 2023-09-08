//PROJECT NAME: Logistics
//CLASS NAME: ProfilesDunningReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ProfilesDunningReport : IProfilesDunningReport
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfilesDunningReport(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfilesDunningReportSp(string PStartingCustomer = null,
		string PEndingCustomer = null,
		string PDunningGroup = null,
		int? PStartingDunningStage = null,
		int? PEndingDunningStage = null,
		string PSiteGroup = null,
		int? PCommit = 0,
		DateTime? PCutoffDate = null,
		int? PCutoffDateOffset = null,
		string pSite = null)
		{
			CustNumType _PStartingCustomer = PStartingCustomer;
			CustNumType _PEndingCustomer = PEndingCustomer;
			DunningGroupType _PDunningGroup = PDunningGroup;
			DunningStageType _PStartingDunningStage = PStartingDunningStage;
			DunningStageType _PEndingDunningStage = PEndingDunningStage;
			SiteGroupType _PSiteGroup = PSiteGroup;
			ListYesNoType _PCommit = PCommit;
			DateType _PCutoffDate = PCutoffDate;
			DateOffsetType _PCutoffDateOffset = PCutoffDateOffset;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfilesDunningReportSp";
				
				appDB.AddCommandParameter(cmd, "PStartingCustomer", _PStartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCustomer", _PEndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDunningGroup", _PDunningGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingDunningStage", _PStartingDunningStage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingDunningStage", _PEndingDunningStage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteGroup", _PSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCommit", _PCommit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCutoffDate", _PCutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCutoffDateOffset", _PCutoffDateOffset, ParameterDirection.Input);
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
