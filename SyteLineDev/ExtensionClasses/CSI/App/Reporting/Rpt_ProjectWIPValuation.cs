//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectWIPValuation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjectWIPValuation : IRpt_ProjectWIPValuation
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjectWIPValuation(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectWIPValuationSp(string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ProjNumStarting = null,
		string ProjNumEnding = null,
		string ProjectStatus = null,
		int? DisplayReportHeader = 1,
		string pSite = null)
		{
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			ProjNumType _ProjNumStarting = ProjNumStarting;
			ProjNumType _ProjNumEnding = ProjNumEnding;
			ProjStatusType _ProjectStatus = ProjectStatus;
			ListYesNoType _DisplayReportHeader = DisplayReportHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjectWIPValuationSp";
				
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNumStarting", _ProjNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNumEnding", _ProjNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectStatus", _ProjectStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayReportHeader", _DisplayReportHeader, ParameterDirection.Input);
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
