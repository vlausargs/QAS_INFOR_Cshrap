//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EDIPurchaseOrderStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_EDIPurchaseOrderStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EDIPurchaseOrderStatusSp(DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string CustPoStarting = null,
		string CustPoEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string CustItemStarting = null,
		string CustItemEnding = null,
		short? OrderDateStartingOffset = null,
		short? OrderDateEndingOffset = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		byte? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null);
	}
	
	public class Rpt_EDIPurchaseOrderStatus : IRpt_EDIPurchaseOrderStatus
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EDIPurchaseOrderStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EDIPurchaseOrderStatusSp(DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string CustPoStarting = null,
		string CustPoEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string CustItemStarting = null,
		string CustItemEnding = null,
		short? OrderDateStartingOffset = null,
		short? OrderDateEndingOffset = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		byte? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null)
		{
			DateType _OrderDateStarting = OrderDateStarting;
			DateType _OrderDateEnding = OrderDateEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			CustPoType _CustPoStarting = CustPoStarting;
			CustPoType _CustPoEnding = CustPoEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			CustItemType _CustItemStarting = CustItemStarting;
			CustItemType _CustItemEnding = CustItemEnding;
			DateOffsetType _OrderDateStartingOffset = OrderDateStartingOffset;
			DateOffsetType _OrderDateEndingOffset = OrderDateEndingOffset;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EDIPurchaseOrderStatusSp";
				
				appDB.AddCommandParameter(cmd, "OrderDateStarting", _OrderDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEnding", _OrderDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPoStarting", _CustPoStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPoEnding", _CustPoEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItemStarting", _CustItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItemEnding", _CustItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStartingOffset", _OrderDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEndingOffset", _OrderDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
