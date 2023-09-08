//PROJECT NAME: Logistics
//CLASS NAME: IRebalCustLcr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRebalCustLcr
	{
		(int? ReturnCode, int? LcrCount) RebalCustLcrSp(string BegCustNum,
		string EndCustNum,
		string BegLcrNum,
		string EndLcrNum,
		int? LcrCount);
	}
}

