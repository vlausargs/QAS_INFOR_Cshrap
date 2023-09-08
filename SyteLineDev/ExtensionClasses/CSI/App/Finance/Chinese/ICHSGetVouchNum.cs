//PROJECT NAME: Finance
//CLASS NAME: ICHSGetVouchNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetVouchNum
	{
		(int? ReturnCode,
			string VoucherNumber,
			string Infobar) CHSGetVouchNumSp(
			string TypeCode,
			string blnNew,
			DateTime? TransDate,
			string VoucherNumber,
			string Infobar);
	}
}

