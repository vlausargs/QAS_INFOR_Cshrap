//PROJECT NAME: Data
//CLASS NAME: Home_POFundsCommittedSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Home_POFundsCommittedSub : IHome_POFundsCommittedSub
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Home_POFundsCommittedSub(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Home_POFundsCommittedSubSp(
			string pPoType = null,
			string pPoitemStat = null,
			string pPoStat = null,
			int? pPrintVendItem = null,
			int? pSortByCurrCode = null,
			int? pTransDomCurr = null,
			int? pShowDetail = null,
			int? pUseHistRate = null,
			string pStartPoNum = null,
			string pEndPoNum = null,
			int? pStartPoLine = null,
			int? pEndPoLine = null,
			string pStartVendor = null,
			string pEndVendor = null,
			DateTime? pStartOrderDate = null,
			DateTime? pEndOrderDate = null,
			string pStartVendOrder = null,
			string pEndVendOrder = null,
			string pStartItem = null,
			string pEndItem = null,
			string pStartVendItem = null,
			string pEndVendItem = null,
			DateTime? pStartDueDate = null,
			DateTime? pEndDueDate = null,
			DateTime? pStartRecvDate = null,
			DateTime? pEndRecvDate = null,
			string pStartCurrCode = null,
			string pEndCurrCode = null,
			int? pStartOrderDateOffset = null,
			int? pEndOrderDateOffset = null,
			int? pStartDueDateOffset = null,
			int? pEndDueDateOffset = null,
			int? pStartRecvDateOffset = null,
			int? pEndRecvDateOffset = null,
			int? DisplayHeader = null,
			int? pStartPoRel = null,
			int? pEndPoRel = null,
			int? TaskId = null)
		{
			InfobarType _pPoType = pPoType;
			InfobarType _pPoitemStat = pPoitemStat;
			InfobarType _pPoStat = pPoStat;
			ListYesNoType _pPrintVendItem = pPrintVendItem;
			ListYesNoType _pSortByCurrCode = pSortByCurrCode;
			ListYesNoType _pTransDomCurr = pTransDomCurr;
			ListYesNoType _pShowDetail = pShowDetail;
			ListYesNoType _pUseHistRate = pUseHistRate;
			PoNumType _pStartPoNum = pStartPoNum;
			PoNumType _pEndPoNum = pEndPoNum;
			PoLineType _pStartPoLine = pStartPoLine;
			PoLineType _pEndPoLine = pEndPoLine;
			VendNumType _pStartVendor = pStartVendor;
			VendNumType _pEndVendor = pEndVendor;
			DateType _pStartOrderDate = pStartOrderDate;
			DateType _pEndOrderDate = pEndOrderDate;
			VendOrderType _pStartVendOrder = pStartVendOrder;
			VendOrderType _pEndVendOrder = pEndVendOrder;
			ItemType _pStartItem = pStartItem;
			ItemType _pEndItem = pEndItem;
			VendItemType _pStartVendItem = pStartVendItem;
			VendItemType _pEndVendItem = pEndVendItem;
			DateType _pStartDueDate = pStartDueDate;
			DateType _pEndDueDate = pEndDueDate;
			DateType _pStartRecvDate = pStartRecvDate;
			DateType _pEndRecvDate = pEndRecvDate;
			CurrCodeType _pStartCurrCode = pStartCurrCode;
			CurrCodeType _pEndCurrCode = pEndCurrCode;
			DateOffsetType _pStartOrderDateOffset = pStartOrderDateOffset;
			DateOffsetType _pEndOrderDateOffset = pEndOrderDateOffset;
			DateOffsetType _pStartDueDateOffset = pStartDueDateOffset;
			DateOffsetType _pEndDueDateOffset = pEndDueDateOffset;
			DateOffsetType _pStartRecvDateOffset = pStartRecvDateOffset;
			DateOffsetType _pEndRecvDateOffset = pEndRecvDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			PoReleaseType _pStartPoRel = pStartPoRel;
			PoReleaseType _pEndPoRel = pEndPoRel;
			TaskNumType _TaskId = TaskId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Home_POFundsCommittedSubSp";
				
				appDB.AddCommandParameter(cmd, "pPoType", _pPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoitemStat", _pPoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoStat", _pPoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintVendItem", _pPrintVendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSortByCurrCode", _pSortByCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDomCurr", _pTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShowDetail", _pShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUseHistRate", _pUseHistRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoNum", _pStartPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoNum", _pEndPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoLine", _pStartPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoLine", _pEndPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendor", _pStartVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendor", _pEndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartOrderDate", _pStartOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndOrderDate", _pEndOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendOrder", _pStartVendOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendOrder", _pEndVendOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartItem", _pStartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendItem", _pStartVendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendItem", _pEndVendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDueDate", _pStartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDueDate", _pEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartRecvDate", _pStartRecvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndRecvDate", _pEndRecvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartCurrCode", _pStartCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCurrCode", _pEndCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartOrderDateOffset", _pStartOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndOrderDateOffset", _pEndOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDueDateOffset", _pStartDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDueDateOffset", _pEndDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartRecvDateOffset", _pStartRecvDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndRecvDateOffset", _pEndRecvDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoRel", _pStartPoRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoRel", _pEndPoRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
