//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_PipelinebyTerritory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_PipelinebyTerritory
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PipelinebyTerritorySp(string TerritoryCode = null,
		byte? ChanceToClose = null,
		int? PageNum = null,
		int? EntriesPerPage = null,
		string SiteRef = null);
	}
	
	public class CLM_PipelinebyTerritory : ICLM_PipelinebyTerritory
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PipelinebyTerritory(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PipelinebyTerritorySp(string TerritoryCode = null,
		byte? ChanceToClose = null,
		int? PageNum = null,
		int? EntriesPerPage = null,
		string SiteRef = null)
		{
			TerritoryCodeType _TerritoryCode = TerritoryCode;
			OpportunityClosePercentType _ChanceToClose = ChanceToClose;
			IntType _PageNum = PageNum;
			IntType _EntriesPerPage = EntriesPerPage;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_PipelinebyTerritorySp";
				
				appDB.AddCommandParameter(cmd, "TerritoryCode", _TerritoryCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChanceToClose", _ChanceToClose, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageNum", _PageNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntriesPerPage", _EntriesPerPage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
