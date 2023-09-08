//PROJECT NAME: Logistics
//CLASS NAME: IChangePOInvalidDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IChangePOInvalidDueDate
	{
		(int? ReturnCode, string Infobar) ChangePOInvalidDueDateSp(int? Selected,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		string PoVendNum,
		DateTime? OldDueDate,
		DateTime? NewDueDate,
		string Infobar);
	}
}

