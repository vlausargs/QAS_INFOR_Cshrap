//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_OrderStatus : IRpt_OrderStatus
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_OrderStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderStatusSp(string ExOptBegCust_num = null,
		string ExOptEndCust_num = null,
		string ExOptacCoType = null,
		string ExOptacCoStat = null,
		string ExOptacCoitemStat = null,
		int? ExOptszTransDomCur = null,
		string ExOptCredit_Hold = null,
		int? ExOptgoInclDo = null,
		string ExOptszSite_Group = null,
		string ExOptBegCo_num = null,
		string ExOptEndCo_num = null,
		DateTime? ExOptBegOrder_date = null,
		DateTime? ExOptEndOrder_date = null,
		string ExOptBegCust_Po = null,
		string ExOptEndCust_Po = null,
		string ExOptBegItem = null,
		string ExOptEndItem = null,
		string ExOptBegCust_Item = null,
		string ExOptEndCust_Item = null,
		DateTime? ExOptBegDue_date = null,
		DateTime? ExOptEndDue_date = null,
		DateTime? ExOptBegShip_date = null,
		DateTime? ExOptEndShip_date = null,
		string StartWhse = null,
		string EndWhse = null,
		int? StartOrder_dateOffset = null,
		int? EndOrder_dateOffset = null,
		int? StartDue_dateOffset = null,
		int? EndDue_dateOffset = null,
		int? StartShip_dateOffset = null,
		int? EndShip_dateOffset = null,
		string SortBy = null,
		int? DisplayHeader = null,
		int? PrintPrice = 0,
		int? PrintCost = 0,
		int? PrintInternalNotes = null,
		int? PrintExternalNotes = null,
		int? TaskId = null,
		int? BackOrderOnly = null,
		string pSite = null)
		{
			CustNumType _ExOptBegCust_num = ExOptBegCust_num;
			CustNumType _ExOptEndCust_num = ExOptEndCust_num;
			InfobarType _ExOptacCoType = ExOptacCoType;
			InfobarType _ExOptacCoStat = ExOptacCoStat;
			InfobarType _ExOptacCoitemStat = ExOptacCoitemStat;
			ListYesNoType _ExOptszTransDomCur = ExOptszTransDomCur;
			StringType _ExOptCredit_Hold = ExOptCredit_Hold;
			ListYesNoType _ExOptgoInclDo = ExOptgoInclDo;
			SiteGroupType _ExOptszSite_Group = ExOptszSite_Group;
			CoNumType _ExOptBegCo_num = ExOptBegCo_num;
			CoNumType _ExOptEndCo_num = ExOptEndCo_num;
			DateType _ExOptBegOrder_date = ExOptBegOrder_date;
			DateType _ExOptEndOrder_date = ExOptEndOrder_date;
			CustPoType _ExOptBegCust_Po = ExOptBegCust_Po;
			CustPoType _ExOptEndCust_Po = ExOptEndCust_Po;
			ItemType _ExOptBegItem = ExOptBegItem;
			ItemType _ExOptEndItem = ExOptEndItem;
			CustItemType _ExOptBegCust_Item = ExOptBegCust_Item;
			CustItemType _ExOptEndCust_Item = ExOptEndCust_Item;
			DateType _ExOptBegDue_date = ExOptBegDue_date;
			DateType _ExOptEndDue_date = ExOptEndDue_date;
			DateType _ExOptBegShip_date = ExOptBegShip_date;
			DateType _ExOptEndShip_date = ExOptEndShip_date;
			WhseType _StartWhse = StartWhse;
			WhseType _EndWhse = EndWhse;
			DateOffsetType _StartOrder_dateOffset = StartOrder_dateOffset;
			DateOffsetType _EndOrder_dateOffset = EndOrder_dateOffset;
			DateOffsetType _StartDue_dateOffset = StartDue_dateOffset;
			DateOffsetType _EndDue_dateOffset = EndDue_dateOffset;
			DateOffsetType _StartShip_dateOffset = StartShip_dateOffset;
			DateOffsetType _EndShip_dateOffset = EndShip_dateOffset;
			StringType _SortBy = SortBy;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintPrice = PrintPrice;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			TaskNumType _TaskId = TaskId;
			IntType _BackOrderOnly = BackOrderOnly;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_OrderStatusSp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegCust_num", _ExOptBegCust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndCust_num", _ExOptEndCust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacCoType", _ExOptacCoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacCoStat", _ExOptacCoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacCoitemStat", _ExOptacCoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszTransDomCur", _ExOptszTransDomCur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptCredit_Hold", _ExOptCredit_Hold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoInclDo", _ExOptgoInclDo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSite_Group", _ExOptszSite_Group, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegCo_num", _ExOptBegCo_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndCo_num", _ExOptEndCo_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegOrder_date", _ExOptBegOrder_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndOrder_date", _ExOptEndOrder_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegCust_Po", _ExOptBegCust_Po, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndCust_Po", _ExOptEndCust_Po, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegItem", _ExOptBegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndItem", _ExOptEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegCust_Item", _ExOptBegCust_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndCust_Item", _ExOptEndCust_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegDue_date", _ExOptBegDue_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndDue_date", _ExOptEndDue_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegShip_date", _ExOptBegShip_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndShip_date", _ExOptEndShip_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartWhse", _StartWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndWhse", _EndWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrder_dateOffset", _StartOrder_dateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrder_dateOffset", _EndOrder_dateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDue_dateOffset", _StartDue_dateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDue_dateOffset", _EndDue_dateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartShip_dateOffset", _StartShip_dateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndShip_dateOffset", _EndShip_dateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BackOrderOnly", _BackOrderOnly, ParameterDirection.Input);
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
