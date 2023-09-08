//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROInvSubDepositSum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROInvSubDepositSum
	{
		(int? ReturnCode,
			decimal? SRODeposit,
			string Infobar) SSSFSSROInvSubDepositSumSp(
			string SRONum,
			string CustNum,
			string InvNum,
			int? InvSeq,
			decimal? PInvTot,
			int? PDistSeq,
			decimal? SRODeposit,
			string Infobar);
	}
}

