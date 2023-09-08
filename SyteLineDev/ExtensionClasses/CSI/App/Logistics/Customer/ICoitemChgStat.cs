//PROJECT NAME: Logistics
//CLASS NAME: ICoitemChgStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemChgStat
	{
		(int? ReturnCode,
			string Infobar,
			decimal? ItemwhseQtyAllocCo) CoitemChgStatSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			string POldWhse,
			decimal? POldQtyOrdered,
			decimal? POldQtyShipped,
			decimal? POldQtyOrderedConv,
			decimal? POldPriceConv,
			decimal? POldDisc,
			string POldUM,
			decimal? PCoDisc,
			int? PNewRecord,
			string POldStatus,
			string PNewStatus,
			string PNewItem,
			decimal? PNewQtyOrdered,
			string Infobar,
			string ParmsSite = null,
			int? BufferItemwhse = 0,
			decimal? ItemwhseQtyAllocCo = null);
	}
}

