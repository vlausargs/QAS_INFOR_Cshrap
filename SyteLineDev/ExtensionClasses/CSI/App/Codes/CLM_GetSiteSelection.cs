//PROJECT NAME: Codes
//CLASS NAME: CLM_GetSiteSelection.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class CLM_GetSiteSelection : ICLM_GetSiteSelection
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetSiteSelection(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GetSiteSelectionSp(string FilterGroupSelection = null,
		string FilterUnClickSite = null,
		string FilterDeleteSite = null,
		string FilterIntranetName = null,
		string FilterSourceSite = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				LongListType _FilterGroupSelection = FilterGroupSelection;
				LongListType _FilterUnClickSite = FilterUnClickSite;
				LongListType _FilterDeleteSite = FilterDeleteSite;
				IntranetNameType _FilterIntranetName = FilterIntranetName;
				SiteType _FilterSourceSite = FilterSourceSite;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_GetSiteSelectionSp";
					
					appDB.AddCommandParameter(cmd, "FilterGroupSelection", _FilterGroupSelection, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterUnClickSite", _FilterUnClickSite, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterDeleteSite", _FilterDeleteSite, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterIntranetName", _FilterIntranetName, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterSourceSite", _FilterSourceSite, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
