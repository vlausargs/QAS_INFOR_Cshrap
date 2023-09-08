//PROJECT NAME: Logistics
//CLASS NAME: IArinvg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArinvg
	{
		(int? ReturnCode, string Infobar) ArinvgSp(Guid? PArinv,
		string Infobar,
		Guid? EarnedRebateRowPointer = null);
	}
}

