//PROJECT NAME: Data
//CLASS NAME: IUpdateTransferExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdateTransferExchRate
	{
		(int? ReturnCode,
			string Infobar) UpdateTransferExchRateSp(
			string FromSite,
			string ToSite,
			decimal? ExchRate,
			string Infobar);
	}
}

