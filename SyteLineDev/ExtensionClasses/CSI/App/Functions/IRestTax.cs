//PROJECT NAME: Data
//CLASS NAME: IRestTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRestTax
	{
		(int? ReturnCode,
			decimal? RestockTax1,
			decimal? RestockTax2,
			string Infobar) RestTaxSp(
			decimal? RestockAmount,
			string RmaRmaNum,
			int? RmaitemRmaLine,
			string RmaTaxCode1,
			string RmaitemTaxCode1,
			string RmaTaxCode2,
			string RmaitemTaxCode2,
			string CustomerTermsCode,
			string CustaddrCurrCode,
			decimal? RmaExchRate,
			int? RmaUseExchRate,
			int? Places,
			Guid? AltProcessId,
			decimal? RestockTax1,
			decimal? RestockTax2,
			string Infobar);
	}
}

