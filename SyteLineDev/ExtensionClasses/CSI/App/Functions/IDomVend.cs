//PROJECT NAME: Data
//CLASS NAME: IDomVend.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDomVend
	{
		(int? ReturnCode,
			decimal? ExchRate,
			int? FixedRate,
			string Infobar) DomVendSp(
			string VendNum,
			string CurrCode = null,
			decimal? ConvRate = null,
			string TEuroCurr = null,
			int? IncludeRcpt = null,
			string RcptPoNum = null,
			decimal? ExchRate = null,
			int? FixedRate = null,
			string Infobar = null);
	}
}

