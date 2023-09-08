//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBBankStmEntryDetailTran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CLM_ESBBankStmEntryDetailTran : ICLM_ESBBankStmEntryDetailTran
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ESBBankStmEntryDetailTran(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) CLM_ESBBankStmEntryDetailTranSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		string FilterString,
		string CollectionName,
		string TextPrefix = null,
		string FilterObject = null,
		string InfoBar = null)
		{
			MarkupDocumentNameType _BODNoun = BODNoun;
			MarkupDocumentNameType _BODVerb = BODVerb;
			MarkupDocumentNameType _DocumentID = DocumentID;
			LongListType _FilterString = FilterString;
			MarkupDocumentNameType _CollectionName = CollectionName;
			MarkupDocumentNameType _TextPrefix = TextPrefix;
			MarkupDocumentNameType _FilterObject = FilterObject;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ESBBankStmEntryDetailTranSp";
				
				appDB.AddCommandParameter(cmd, "BODNoun", _BODNoun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BODVerb", _BODVerb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CollectionName", _CollectionName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TextPrefix", _TextPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterObject", _FilterObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, InfoBar);
			}
		}
	}
}
