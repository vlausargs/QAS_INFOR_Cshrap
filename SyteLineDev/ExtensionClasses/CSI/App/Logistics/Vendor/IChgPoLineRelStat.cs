//PROJECT NAME: Logistics
//CLASS NAME: IChgPoLineRelStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IChgPoLineRelStat
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode,
		string Infobar) ChgPoLineRelStatSp(
			string ProcSel,
			string IPoStat,
			string IPoType,
			string SPoNum,
			string EPoNum,
			int? SPoLine,
			int? EPoLine,
			int? SPoRelease,
			int? EPoRelease,
			string SPoVendNum,
			string EPoVendNum,
			DateTime? SPoOrderDate,
			DateTime? EPoOrderDate,
			DateTime? SPoitemDueDate,
			DateTime? EPoitemDueDate,
			DateTime? SPoitemRelDate,
			DateTime? EPoitemRelDate,
			string Infobar,
			int? StartOrderDateOffset = null,
			int? EndOrderDateOffset = null,
			int? StartDueDateOffset = null,
			int? EndDueDateOffset = null,
			int? StartRelDateOffset = null,
			int? EndRelDateOffset = null);
	}
}

