//PROJECT NAME: Finance
//CLASS NAME: ICHSUpdateLastVouchNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSUpdateLastVouchNum
	{
		(int? ReturnCode,
			string Infobar) CHSUpdateLastVouchNumSp(
			string TypeCode,
			DateTime? TransDate,
			string VoucherNumber,
			string Infobar);
	}
}

