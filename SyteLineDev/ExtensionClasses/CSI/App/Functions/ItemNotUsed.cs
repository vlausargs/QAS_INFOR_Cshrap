//PROJECT NAME: Data
//CLASS NAME: ItemNotUsed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemNotUsed : IItemNotUsed
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ItemNotUsed(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ItemNotUsedSp(
			string TransactionType = "ABCDEFGHILMNOPRSTW",
			string RefType = "IORPJTSKWCF",
			DateTime? TransDateStarting = null,
			DateTime? TransDateEnding = null,
			string WarehouseStarting = null,
			string WarehouseEnding = null,
			string ProductCodeStarting = null,
			string ProductCodeEnding = null,
			string ItemStarting = null,
			string ItemEnding = null,
			string LocationStarting = null,
			string LocationEnding = null,
			string PlannerCodeStarting = null,
			string PlannerCodeEnding = null,
			decimal? TransNumStarting = null,
			decimal? TransNumEnding = null,
			string ReasonCodeStarting = null,
			string ReasonCodeEnding = null,
			int? TransDateStartingOffset = null,
			int? TransDateEndingOffset = null,
			int? DisplayHeader = null)
		{
			StringType _TransactionType = TransactionType;
			StringType _RefType = RefType;
			GenericDateType _TransDateStarting = TransDateStarting;
			GenericDateType _TransDateEnding = TransDateEnding;
			WhseType _WarehouseStarting = WarehouseStarting;
			WhseType _WarehouseEnding = WarehouseEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			LocType _LocationStarting = LocationStarting;
			LocType _LocationEnding = LocationEnding;
			UserCodeType _PlannerCodeStarting = PlannerCodeStarting;
			UserCodeType _PlannerCodeEnding = PlannerCodeEnding;
			MatlTransNumType _TransNumStarting = TransNumStarting;
			MatlTransNumType _TransNumEnding = TransNumEnding;
			ReasonCodeType _ReasonCodeStarting = ReasonCodeStarting;
			ReasonCodeType _ReasonCodeEnding = ReasonCodeEnding;
			DateOffsetType _TransDateStartingOffset = TransDateStartingOffset;
			DateOffsetType _TransDateEndingOffset = TransDateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemNotUsedSp";
				
				appDB.AddCommandParameter(cmd, "TransactionType", _TransactionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarehouseStarting", _WarehouseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarehouseEnding", _WarehouseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocationStarting", _LocationStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocationEnding", _LocationEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeStarting", _PlannerCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeEnding", _PlannerCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNumStarting", _TransNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNumEnding", _TransNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCodeStarting", _ReasonCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCodeEnding", _ReasonCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStartingOffset", _TransDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEndingOffset", _TransDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
