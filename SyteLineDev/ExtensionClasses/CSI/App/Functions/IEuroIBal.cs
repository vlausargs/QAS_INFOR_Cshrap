//PROJECT NAME: Data
//CLASS NAME: IEuroIBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEuroIBal
	{
		(int? ReturnCode,
			decimal? rNetDue) EuroIBalSp(
			string pCustNum,
			string pInvNum,
			decimal? rNetDue);
	}
}

