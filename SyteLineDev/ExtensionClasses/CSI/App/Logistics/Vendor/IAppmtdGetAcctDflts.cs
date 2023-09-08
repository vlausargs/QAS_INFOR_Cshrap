//PROJECT NAME: Logistics
//CLASS NAME: IAppmtdGetAcctDflts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtdGetAcctDflts
	{
		(int? ReturnCode,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PAcctDesc,
			string Infobar,
			int? PAcctIsControl) AppmtdGetAcctDfltsSp(
			string PSite,
			string PType,
			string PVendNum,
			decimal? PDiscAmt,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PAcctDesc,
			string Infobar,
			int? PAcctIsControl);
	}
}

