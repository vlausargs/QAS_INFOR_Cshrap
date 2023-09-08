//PROJECT NAME: Logistics
//CLASS NAME: IGetCoCompEnableFlags.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetCoCompEnableFlags
	{
		(int? ReturnCode, int? EdiOrder,
		int? LcrRequired,
		int? EnableOrderType,
		int? EnableConsolidate,
		int? EnableEffExpDate,
		string Infobar) GetCoCompEnableFlagsSp(string CoNum,
		string CustNum,
		int? UseExchRate,
		int? EdiOrder,
		int? LcrRequired,
		int? EnableOrderType,
		int? EnableConsolidate,
		int? EnableEffExpDate,
		string Infobar);
	}
}

