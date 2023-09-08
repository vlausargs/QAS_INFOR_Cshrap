//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectedItemCompletionsbyResourceGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjectedItemCompletionsbyResourceGroup : IRpt_ProjectedItemCompletionsbyResourceGroup
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjectedItemCompletionsbyResourceGroup(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectedItemCompletionsbyResourceGroupSp(string ScheduleTypes = null,
		string StartingResource = null,
		string EndingResource = null,
		string StartingResourceGroup = null,
		string EndingResourceGroup = null,
		DateTime? StartingDate = null,
		DateTime? EndingDate = null,
		int? StartingDateOffset = null,
		int? EndingDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			InfobarType _ScheduleTypes = ScheduleTypes;
			ApsResourceType _StartingResource = StartingResource;
			ApsResourceType _EndingResource = EndingResource;
			ApsResourceType _StartingResourceGroup = StartingResourceGroup;
			ApsResourceType _EndingResourceGroup = EndingResourceGroup;
			DateTimeType _StartingDate = StartingDate;
			DateTimeType _EndingDate = EndingDate;
			DateOffsetType _StartingDateOffset = StartingDateOffset;
			DateOffsetType _EndingDateOffset = EndingDateOffset;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjectedItemCompletionsbyResourceGroupSp";
				
				appDB.AddCommandParameter(cmd, "ScheduleTypes", _ScheduleTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingResource", _StartingResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingResource", _EndingResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingResourceGroup", _StartingResourceGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingResourceGroup", _EndingResourceGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDate", _StartingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDate", _EndingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDateOffset", _StartingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDateOffset", _EndingDateOffset, ParameterDirection.Input);
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
