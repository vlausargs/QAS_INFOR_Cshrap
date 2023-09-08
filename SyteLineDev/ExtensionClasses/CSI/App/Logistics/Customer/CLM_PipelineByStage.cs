//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_PipelineByStage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_PipelineByStage
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PipelineByStageSP(string OppStage = null,
		int? PageNum = null,
		int? EntriesPerPage = null,
		string SiteRef = null);
	}
	
	public class CLM_PipelineByStage : ICLM_PipelineByStage
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PipelineByStage(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PipelineByStageSP(string OppStage = null,
		int? PageNum = null,
		int? EntriesPerPage = null,
		string SiteRef = null)
		{
			OpportunityStageType _OppStage = OppStage;
			IntType _PageNum = PageNum;
			IntType _EntriesPerPage = EntriesPerPage;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_PipelineByStageSP";
				
				appDB.AddCommandParameter(cmd, "OppStage", _OppStage, ParameterDirection.Input);
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
