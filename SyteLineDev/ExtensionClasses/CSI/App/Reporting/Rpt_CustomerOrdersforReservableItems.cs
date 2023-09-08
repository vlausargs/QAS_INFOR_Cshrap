//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerOrdersforReservableItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_CustomerOrdersforReservableItems
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerOrdersforReservableItemsSp(string WhseStarting = null,
		string WhseEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		byte? SortByDueDate = null,
		string DisplayOrder = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		short? DueDateStartingOffset = null,
		short? DueDateEndingOffset = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string CustStarting = null,
		string CustEnding = null,
		byte? DisplayHeader = (byte)1,
		string pSite = null);
	}
	
	public class Rpt_CustomerOrdersforReservableItems : IRpt_CustomerOrdersforReservableItems
	{
		IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CustomerOrdersforReservableItems(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerOrdersforReservableItemsSp(string WhseStarting = null,
		string WhseEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		byte? SortByDueDate = null,
		string DisplayOrder = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		short? DueDateStartingOffset = null,
		short? DueDateEndingOffset = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string CustStarting = null,
		string CustEnding = null,
		byte? DisplayHeader = (byte)1,
		string pSite = null)
		{
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			FlagNyType _SortByDueDate = SortByDueDate;
			StringType _DisplayOrder = DisplayOrder;
			DateType _DueDateStarting = DueDateStarting;
			DateType _DueDateEnding = DueDateEnding;
			DateOffsetType _DueDateStartingOffset = DueDateStartingOffset;
			DateOffsetType _DueDateEndingOffset = DueDateEndingOffset;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			CustNumType _CustStarting = CustStarting;
			CustNumType _CustEnding = CustEnding;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CustomerOrdersforReservableItemsSp";
				
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortByDueDate", _SortByDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayOrder", _DisplayOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStartingOffset", _DueDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEndingOffset", _DueDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustStarting", _CustStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustEnding", _CustEnding, ParameterDirection.Input);
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
