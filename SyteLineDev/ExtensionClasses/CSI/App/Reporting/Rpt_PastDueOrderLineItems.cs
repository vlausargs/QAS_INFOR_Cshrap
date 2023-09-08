//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PastDueOrderLineItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PastDueOrderLineItems : IRpt_PastDueOrderLineItems
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PastDueOrderLineItems(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PastDueOrderLineItemsSp(DateTime? pAsOfDate = null,
		string pCoType = null,
		string pCoStat = null,
		string pCoitemStat = null,
		string pcredit_hold = null,
		string pBegItem = null,
		string pEndItem = null,
		string pBegCI = null,
		string pEndCI = null,
		DateTime? pBegDueDate = null,
		DateTime? pEndDueDate = null,
		DateTime? pBegLastShipDate = null,
		DateTime? pEndLastShipDate = null,
		string pBegOrder = null,
		string pEndOrder = null,
		string pBegCustomer = null,
		string pEndCustomer = null,
		DateTime? pBegOrderDate = null,
		DateTime? pEndOrderDate = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? StartDateDueDateOffset = null,
		int? EndDateDueDateOffset = null,
		int? StartDateShipDateOffset = null,
		int? EndDateShipDateOffset = null,
		int? DateOffset = null,
		int? pDisplayHeader = null,
		string pSite = null)
		{
			DateType _pAsOfDate = pAsOfDate;
			InfobarType _pCoType = pCoType;
			InfobarType _pCoStat = pCoStat;
			InfobarType _pCoitemStat = pCoitemStat;
			StringType _pcredit_hold = pcredit_hold;
			ItemType _pBegItem = pBegItem;
			ItemType _pEndItem = pEndItem;
			CustItemType _pBegCI = pBegCI;
			CustItemType _pEndCI = pEndCI;
			DateType _pBegDueDate = pBegDueDate;
			DateType _pEndDueDate = pEndDueDate;
			DateType _pBegLastShipDate = pBegLastShipDate;
			DateType _pEndLastShipDate = pEndLastShipDate;
			CoNumType _pBegOrder = pBegOrder;
			CoNumType _pEndOrder = pEndOrder;
			CustNumType _pBegCustomer = pBegCustomer;
			CustNumType _pEndCustomer = pEndCustomer;
			DateType _pBegOrderDate = pBegOrderDate;
			DateType _pEndOrderDate = pEndOrderDate;
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			DateOffsetType _StartDateDueDateOffset = StartDateDueDateOffset;
			DateOffsetType _EndDateDueDateOffset = EndDateDueDateOffset;
			DateOffsetType _StartDateShipDateOffset = StartDateShipDateOffset;
			DateOffsetType _EndDateShipDateOffset = EndDateShipDateOffset;
			DateOffsetType _DateOffset = DateOffset;
			ListYesNoType _pDisplayHeader = pDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PastDueOrderLineItemsSp";
				
				appDB.AddCommandParameter(cmd, "pAsOfDate", _pAsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoType", _pCoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoStat", _pCoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoitemStat", _pCoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pcredit_hold", _pcredit_hold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegItem", _pBegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegCI", _pBegCI, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCI", _pEndCI, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegDueDate", _pBegDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDueDate", _pEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegLastShipDate", _pBegLastShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndLastShipDate", _pEndLastShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegOrder", _pBegOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndOrder", _pEndOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegCustomer", _pBegCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustomer", _pEndCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegOrderDate", _pBegOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndOrderDate", _pEndOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateDueDateOffset", _StartDateDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateDueDateOffset", _EndDateDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateShipDateOffset", _StartDateShipDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateShipDateOffset", _EndDateShipDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateOffset", _DateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDisplayHeader", _pDisplayHeader, ParameterDirection.Input);
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
