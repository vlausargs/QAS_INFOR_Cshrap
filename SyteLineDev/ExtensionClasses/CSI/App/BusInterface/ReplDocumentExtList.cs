//PROJECT NAME: BusInterface
//CLASS NAME: ReplDocumentExtList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class ReplDocumentExtList : IReplDocumentExtList
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ReplDocumentExtList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) ReplDocumentExtListSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		string TextPrefix,
		string IDOCollection,
		string Nodes,
		string FilterObject,
		string InfoBar,
		int? CallFromDetail = null,
		string ParentNode = null)
		{
			MarkupDocumentNameType _BODNoun = BODNoun;
			MarkupDocumentNameType _BODVerb = BODVerb;
			MarkupDocumentNameType _DocumentID = DocumentID;
			MarkupDocumentNameType _TextPrefix = TextPrefix;
			MarkupDocumentNameType _IDOCollection = IDOCollection;
			MarkupDocumentNameType _Nodes = Nodes;
			LongListType _FilterObject = FilterObject;
			InfobarType _InfoBar = InfoBar;
			ListYesNoType _CallFromDetail = CallFromDetail;
			MarkupDocumentNameType _ParentNode = ParentNode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReplDocumentExtListSp";
				
				appDB.AddCommandParameter(cmd, "BODNoun", _BODNoun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BODVerb", _BODVerb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TextPrefix", _TextPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IDOCollection", _IDOCollection, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Nodes", _Nodes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterObject", _FilterObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CallFromDetail", _CallFromDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentNode", _ParentNode, ParameterDirection.Input);
				
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
