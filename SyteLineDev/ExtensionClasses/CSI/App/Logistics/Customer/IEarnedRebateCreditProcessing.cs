//PROJECT NAME: Logistics
//CLASS NAME: IEarnedRebateCreditProcessing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEarnedRebateCreditProcessing
	{
		(int? ReturnCode, string Infobar) EarnedRebateCreditProcessingSp(Guid? EarnedRebateRowPointer,
		DateTime? ApplicationDate,
		string Infobar);
	}
}

