//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalKbaseSearch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSPortalKbaseSearch : ISSSFSPortalKbaseSearch
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSPortalKbaseSearch(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSPortalKbaseSearchSp(string SearchType,
		string SearchText,
		int? SearchKeywords,
		int? SearchDescription,
		int? SearchSummary,
		int? SearchResolution,
		string CatGeneral,
		string CatSpecific,
		string CreatedBy,
		string UpdatedBy,
		string AvailableList)
		{
			StringType _SearchType = SearchType;
			StringType _SearchText = SearchText;
			ListYesNoType _SearchKeywords = SearchKeywords;
			ListYesNoType _SearchDescription = SearchDescription;
			ListYesNoType _SearchSummary = SearchSummary;
			ListYesNoType _SearchResolution = SearchResolution;
			FSKBGeneralType _CatGeneral = CatGeneral;
			FSKBSpecificType _CatSpecific = CatSpecific;
			UsernameType _CreatedBy = CreatedBy;
			UsernameType _UpdatedBy = UpdatedBy;
			StringType _AvailableList = AvailableList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalKbaseSearchSp";
				
				appDB.AddCommandParameter(cmd, "SearchType", _SearchType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SearchText", _SearchText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SearchKeywords", _SearchKeywords, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SearchDescription", _SearchDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SearchSummary", _SearchSummary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SearchResolution", _SearchResolution, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CatGeneral", _CatGeneral, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CatSpecific", _CatSpecific, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreatedBy", _CreatedBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdatedBy", _UpdatedBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AvailableList", _AvailableList, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
