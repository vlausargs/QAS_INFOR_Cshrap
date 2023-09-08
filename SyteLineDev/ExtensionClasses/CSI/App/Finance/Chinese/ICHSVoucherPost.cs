//PROJECT NAME: Finance
//CLASS NAME: ICHSVoucherPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSVoucherPost
	{
		(int? ReturnCode, string Infobar) CHSVoucherPostSp(DateTime? trans_dateP,
		string CrntNmbr,
		string TypeCode,
		string UserName,
		string CalledFrom = null,
		string Infobar = null);
	}
}

