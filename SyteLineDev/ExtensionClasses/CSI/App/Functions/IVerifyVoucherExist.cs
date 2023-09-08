//PROJECT NAME: Data
//CLASS NAME: IVerifyVoucherExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVerifyVoucherExist
	{
		(int? ReturnCode,
			int? ValidVoucher) VerifyVoucherExistSp(
			string RVendNum,
			int? RVoucher,
			int? ValidVoucher);
	}
}

