//PROJECT NAME: Data
//CLASS NAME: IUpdIwhs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdIwhs
	{
		(int? ReturnCode,
			string Infobar,
			decimal? ItemcustPurchYtdOld,
			decimal? ItemcustPurchYtdNew,
			decimal? ItemcustOrderYtdOld,
			decimal? ItemcustOrderYtdNew,
			decimal? ItemcustOrderPtdOld,
			decimal? ItemcustOrderPtdNew,
			decimal? ItemwhseQtyAllocCoOld,
			decimal? ItemwhseQtyAllocCoNew) UpdIwhsSp(
			string ParmCoNum,
			string ParmCoCustNum,
			string ParmNewStat,
			decimal? ParmOldQtyOrderedConv,
			decimal? ParmOldQtyOrdered,
			string ParmOldItem,
			string ParmOldUM,
			string ParmOldWhse,
			string ParmNewWhse,
			decimal? ParmOldQtyShipped,
			string ParmOldStatus,
			decimal? ParmNewQtyOrderedConv,
			decimal? ParmNewQtyOrdered,
			string ParmNewItem,
			string ParmNewUM,
			string ParmCustItem,
			int? ParmNewRecord,
			string Infobar,
			int? BufferItemwhse = 0,
			decimal? ItemcustPurchYtdOld = null,
			decimal? ItemcustPurchYtdNew = null,
			decimal? ItemcustOrderYtdOld = null,
			decimal? ItemcustOrderYtdNew = null,
			decimal? ItemcustOrderPtdOld = null,
			decimal? ItemcustOrderPtdNew = null,
			decimal? ItemwhseQtyAllocCoOld = null,
			decimal? ItemwhseQtyAllocCoNew = null);
	}
}

