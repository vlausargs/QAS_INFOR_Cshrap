//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BarcodedResources.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_BarcodedResources
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_BarcodedResourcesSp(int? LabelSets = 2,
		string ResourceGroupStarting = null,
		string ResourceGroupEnding = null,
		string pSite = null);
	}
	
	public class Rpt_BarcodedResources : IRpt_BarcodedResources
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_BarcodedResources(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_BarcodedResourcesSp(int? LabelSets = 2,
		string ResourceGroupStarting = null,
		string ResourceGroupEnding = null,
		string pSite = null)
		{
			IntType _LabelSets = LabelSets;
			ApsResgroupType _ResourceGroupStarting = ResourceGroupStarting;
			ApsResgroupType _ResourceGroupEnding = ResourceGroupEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_BarcodedResourcesSp";
				
				appDB.AddCommandParameter(cmd, "LabelSets", _LabelSets, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceGroupStarting", _ResourceGroupStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceGroupEnding", _ResourceGroupEnding, ParameterDirection.Input);
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
