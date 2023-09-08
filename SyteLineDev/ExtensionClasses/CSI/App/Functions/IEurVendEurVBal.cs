//PROJECT NAME: Data
//CLASS NAME: IEurVendEurVBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEurVendEurVBal
	{
		(int? ReturnCode,
			decimal? pNetDue) EurVendEurVBalSp(
			string pVendNum,
			int? pVoucher,
			decimal? pNetDue);
	}
}

