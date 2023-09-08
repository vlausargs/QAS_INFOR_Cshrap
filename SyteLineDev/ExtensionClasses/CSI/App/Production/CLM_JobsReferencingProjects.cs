//PROJECT NAME: Production
//CLASS NAME: CLM_JobsReferencingProjects.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CLM_JobsReferencingProjects : ICLM_JobsReferencingProjects
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_JobsReferencingProjects(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_JobsReferencingProjectsSp(string ProjMgr = null,
		DateTime? CutoffDate = null,
		string WBSNum = null,
		string FilterString = null,
		string SiteGroup = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				NameType _ProjMgr = ProjMgr;
				DateType _CutoffDate = CutoffDate;
				WbsNumType _WBSNum = WBSNum;
				LongListType _FilterString = FilterString;
				SiteGroupType _SiteGroup = SiteGroup;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_JobsReferencingProjectsSp";
					
					appDB.AddCommandParameter(cmd, "ProjMgr", _ProjMgr, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "WBSNum", _WBSNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
					
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
