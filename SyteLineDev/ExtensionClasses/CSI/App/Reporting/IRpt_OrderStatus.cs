//PROJECT NAME: Reporting
//CLASS NAME: IRpt_OrderStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_OrderStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderStatusSp(string ExOptBegCust_num = null,
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
		string pSite = null);
	}
}

