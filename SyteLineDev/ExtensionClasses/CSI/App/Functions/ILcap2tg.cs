//PROJECT NAME: Data
//CLASS NAME: ILcap2tg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILcap2tg
	{
		(int? ReturnCode,
			decimal? TSalesTax1,
			decimal? TSalesTax2,
			string Infobar) Lcap2tgSp(
			string PoNum,
			string VendNum,
			decimal? TmpFreightSum,
			decimal? TmpBrokerageSum,
			decimal? TmpDutySum,
			decimal? TmpLocFrtSum,
			decimal? TmpInsuranceSum,
			DateTime? InvoiceDate,
			int? PAskFlag,
			decimal? TSalesTax1,
			decimal? TSalesTax2,
			string Infobar);
	}
}

