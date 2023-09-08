//PROJECT NAME: Logistics
//CLASS NAME: IUpdateExchRateInfoByCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUpdateExchRateInfoByCust
	{
		(int? ReturnCode, int? CurAllowOver,
		int? CurpAllowOver) UpdateExchRateInfoByCustSp(string CustNum,
		int? CurAllowOver,
		int? CurpAllowOver);
	}
}

