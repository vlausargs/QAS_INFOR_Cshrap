//PROJECT NAME: Finance
//CLASS NAME: ICHSGenRecurrVoucher.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGenRecurrVoucher
	{
		(int? ReturnCode, string VoucherNumber,
		string Infobar) CHSGenRecurrVoucherSp(DateTime? TransDate,
		int? ID,
		string PreviewYN,
		string UserName,
		string VoucherNumber,
		string Infobar);
	}
}

