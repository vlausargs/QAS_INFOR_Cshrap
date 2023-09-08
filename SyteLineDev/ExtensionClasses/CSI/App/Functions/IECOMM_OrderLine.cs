//PROJECT NAME: Data
//CLASS NAME: IECOMM_OrderLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IECOMM_OrderLine
	{
		(int? ReturnCode,
			int? ErrorOccured,
			string Infobar) ECOMM_OrderLineSp(
			string OrdNumber,
			int? SequenceNumber,
			string ItemID,
			decimal? OrderQty,
			decimal? Cost,
			decimal? ActualSellPrice,
			DateTime? DueDate,
			string WarehouseID,
			string UnitOfMeasure,
			string ItemDescription1,
			string Comment,
			int? ErrorOccured,
			string Infobar);
	}
}

