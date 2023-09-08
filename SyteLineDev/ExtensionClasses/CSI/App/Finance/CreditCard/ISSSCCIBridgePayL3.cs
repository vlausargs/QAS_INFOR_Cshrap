//PROJECT NAME: Finance
//CLASS NAME: ISSSCCIBridgePayL3.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIBridgePayL3
	{
		(int? ReturnCode,
			string CustPo,
			string Level3) SSSCCIBridgePayL3Sp(
			string InvNum,
			string CustPo,
			string Level3);
	}
}

