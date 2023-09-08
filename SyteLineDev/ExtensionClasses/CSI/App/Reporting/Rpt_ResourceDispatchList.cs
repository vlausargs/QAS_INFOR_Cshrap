//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceDispatchList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ResourceDispatchList : IRpt_ResourceDispatchList
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ResourceDispatchList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceDispatchListSp(string ResourceGroupType = null,
		string ResourceStarting = null,
		string ResourceEnding = null,
		string ResourceGroupStarting = null,
		string ResourceGroupEnding = null,
		string ResourceTypeStarting = null,
		string ResourceTypeEnding = null,
		DateTime? ScheduleDateStarting = null,
		DateTime? ScheduleDateEnding = null,
		int? ScheduleDateStartingOffset = null,
		int? ScheduleDateEndingOffset = null,
		int? ShowDateTime = 1,
		int? DisplayHeader = 1,
		string pSite = null)
		{
			InfobarType _ResourceGroupType = ResourceGroupType;
			ApsResourceType _ResourceStarting = ResourceStarting;
			ApsResourceType _ResourceEnding = ResourceEnding;
			ApsResgroupType _ResourceGroupStarting = ResourceGroupStarting;
			ApsResgroupType _ResourceGroupEnding = ResourceGroupEnding;
			ApsRestypeType _ResourceTypeStarting = ResourceTypeStarting;
			ApsRestypeType _ResourceTypeEnding = ResourceTypeEnding;
			DateTimeType _ScheduleDateStarting = ScheduleDateStarting;
			DateTimeType _ScheduleDateEnding = ScheduleDateEnding;
			DateOffsetType _ScheduleDateStartingOffset = ScheduleDateStartingOffset;
			DateOffsetType _ScheduleDateEndingOffset = ScheduleDateEndingOffset;
			ListYesNoType _ShowDateTime = ShowDateTime;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ResourceDispatchListSp";
				
				appDB.AddCommandParameter(cmd, "ResourceGroupType", _ResourceGroupType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceStarting", _ResourceStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceEnding", _ResourceEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceGroupStarting", _ResourceGroupStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceGroupEnding", _ResourceGroupEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceTypeStarting", _ResourceTypeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceTypeEnding", _ResourceTypeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleDateStarting", _ScheduleDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleDateEnding", _ScheduleDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleDateStartingOffset", _ScheduleDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleDateEndingOffset", _ScheduleDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDateTime", _ShowDateTime, ParameterDirection.Input);
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
