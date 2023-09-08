//PROJECT NAME: Finance
//CLASS NAME: ICHSCheckVoucher.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSCheckVoucher
	{
		(int? ReturnCode, string Infobar) CHSCheckVoucherSp(DateTime? trans_date,
		string CrntNmbr,
		string TypeCode,
		string UserName,
		string curr_code,
		string Infobar);
	}
}

