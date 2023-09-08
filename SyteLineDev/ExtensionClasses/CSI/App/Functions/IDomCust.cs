//PROJECT NAME: Data
//CLASS NAME: IDomCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDomCust
	{
		(int? ReturnCode,
			decimal? ExchRate,
			int? FixedRate,
			string Infobar) DomCustSp(
			string CustNum,
			string CurrCode = null,
			decimal? ConvRate = null,
			string TEuroCurr = null,
			decimal? ExchRate = null,
			int? FixedRate = null,
			string Infobar = null);
	}
}

