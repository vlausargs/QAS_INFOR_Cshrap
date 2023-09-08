//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseOrderHistorybyVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PurchaseOrderHistorybyVendor : IRpt_PurchaseOrderHistorybyVendor
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PurchaseOrderHistorybyVendor(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseOrderHistorybyVendorSp(string OrderStarting = null,
		string OrderEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		string VendorStarting = null,
		string VendorEnding = null,
		string VendOrderStarting = null,
		string VendOrderEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string VendItemStarting = null,
		string VendItemEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		DateTime? LastRcvdDateStarting = null,
		DateTime? LastRcvdDateEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		string POType = null,
		int? IncludeGRN = null,
		int? TranslateToDomesticCurrency = null,
		int? OrderDateStartingOffset = null,
		int? OrderDateEndingOffset = null,
		int? LastRcvdDateStartingOffset = null,
		int? LastRcvdDateEndingOffset = null,
		int? DueDateStartingOffset = null,
		int? DueDateEndingOffset = null,
		int? ShowCost = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			PoNumType _OrderStarting = OrderStarting;
			PoNumType _OrderEnding = OrderEnding;
			DateType _OrderDateStarting = OrderDateStarting;
			DateType _OrderDateEnding = OrderDateEnding;
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			VendOrderType _VendOrderStarting = VendOrderStarting;
			VendOrderType _VendOrderEnding = VendOrderEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			VendItemType _VendItemStarting = VendItemStarting;
			VendItemType _VendItemEnding = VendItemEnding;
			DateType _DueDateStarting = DueDateStarting;
			DateType _DueDateEnding = DueDateEnding;
			DateType _LastRcvdDateStarting = LastRcvdDateStarting;
			DateType _LastRcvdDateEnding = LastRcvdDateEnding;
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			LongListType _POType = POType;
			ListYesNoType _IncludeGRN = IncludeGRN;
			ListYesNoType _TranslateToDomesticCurrency = TranslateToDomesticCurrency;
			DateOffsetType _OrderDateStartingOffset = OrderDateStartingOffset;
			DateOffsetType _OrderDateEndingOffset = OrderDateEndingOffset;
			DateOffsetType _LastRcvdDateStartingOffset = LastRcvdDateStartingOffset;
			DateOffsetType _LastRcvdDateEndingOffset = LastRcvdDateEndingOffset;
			DateOffsetType _DueDateStartingOffset = DueDateStartingOffset;
			DateOffsetType _DueDateEndingOffset = DueDateEndingOffset;
			ListYesNoType _ShowCost = ShowCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PurchaseOrderHistorybyVendorSp";
				
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStarting", _OrderDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEnding", _OrderDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendOrderStarting", _VendOrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendOrderEnding", _VendOrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendItemStarting", _VendItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendItemEnding", _VendItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastRcvdDateStarting", _LastRcvdDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastRcvdDateEnding", _LastRcvdDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POType", _POType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeGRN", _IncludeGRN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranslateToDomesticCurrency", _TranslateToDomesticCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStartingOffset", _OrderDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEndingOffset", _OrderDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastRcvdDateStartingOffset", _LastRcvdDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastRcvdDateEndingOffset", _LastRcvdDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStartingOffset", _DueDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEndingOffset", _DueDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowCost", _ShowCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
