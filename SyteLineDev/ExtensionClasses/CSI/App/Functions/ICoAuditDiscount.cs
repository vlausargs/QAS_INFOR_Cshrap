//PROJECT NAME: Data
//CLASS NAME: ICoAuditDiscount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoAuditDiscount
	{
		(int? ReturnCode,
			string Infobar) CoAuditDiscountSp(
			string PCoNum,
			decimal? POldCoDisc,
			decimal? PNewCoDisc,
			string Infobar);
	}
}

