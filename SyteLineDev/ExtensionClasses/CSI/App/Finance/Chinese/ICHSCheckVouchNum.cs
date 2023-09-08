//PROJECT NAME: Data
//CLASS NAME: ICHSCheckVouchNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSCheckVouchNum
	{
		(int? ReturnCode,
			string Infobar) CHSCheckVouchNumSp(
			string TypeCode,
			DateTime? TransDate,
			string VoucherNumber,
			string Infobar);
	}
}

