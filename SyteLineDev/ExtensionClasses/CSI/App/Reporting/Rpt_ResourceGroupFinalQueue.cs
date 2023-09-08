//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceGroupFinalQueue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ResourceGroupFinalQueue : IRpt_ResourceGroupFinalQueue
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ResourceGroupFinalQueue(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceGroupFinalQueueSp(string ResourceStarting = null,
		string ResourceEnding = null,
		string ResourceGroupStarting = null,
		string ResourceGroupEnding = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			ApsResourceType _ResourceStarting = ResourceStarting;
			ApsResourceType _ResourceEnding = ResourceEnding;
			ApsResgroupType _ResourceGroupStarting = ResourceGroupStarting;
			ApsResgroupType _ResourceGroupEnding = ResourceGroupEnding;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ResourceGroupFinalQueueSp";
				
				appDB.AddCommandParameter(cmd, "ResourceStarting", _ResourceStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceEnding", _ResourceEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceGroupStarting", _ResourceGroupStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceGroupEnding", _ResourceGroupEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
