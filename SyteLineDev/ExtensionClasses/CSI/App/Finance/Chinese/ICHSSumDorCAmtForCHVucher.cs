//PROJECT NAME: Finance
//CLASS NAME: ICHSSumDorCAmtForCHVucher.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSSumDorCAmtForCHVucher
	{
		(int? ReturnCode,
			string Infobar) CHSSumDorCAmtForCHVucherSp(
			string TypeCode,
			string CrntNmbr,
			DateTime? Trans_Date,
			string Infobar);
	}
}

