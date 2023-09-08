//PROJECT NAME: Material
//CLASS NAME: Rpt_SubItemRevisionECNItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class Rpt_SubItemRevisionECNItems : IRpt_SubItemRevisionECNItems
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SubItemRevisionECNItems(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SubItemRevisionECNItemsSp(string ItemItem = null,
		string ItemRevision = null,
		int? ECNNumStarting = null,
		int? ECNNumEnding = null,
		int? PrintECNItemsNotes = null,
		int? PrintInternalNotes = null,
		int? PrintExternalNotes = null,
		string pSite = null)
		{
			ItemType _ItemItem = ItemItem;
			RevisionType _ItemRevision = ItemRevision;
			EcnNumType _ECNNumStarting = ECNNumStarting;
			EcnNumType _ECNNumEnding = ECNNumEnding;
			FlagNyType _PrintECNItemsNotes = PrintECNItemsNotes;
			FlagNyType _PrintInternalNotes = PrintInternalNotes;
			FlagNyType _PrintExternalNotes = PrintExternalNotes;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SubItemRevisionECNItemsSp";
				
				appDB.AddCommandParameter(cmd, "ItemItem", _ItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemRevision", _ItemRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECNNumStarting", _ECNNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECNNumEnding", _ECNNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintECNItemsNotes", _PrintECNItemsNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
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
