//PROJECT NAME: Finance
//CLASS NAME: IArpmtGetReapInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtGetReapInfo
	{
		(int? ReturnCode,
			DateTime? PInvDate) ArpmtGetReapInfoSp(
			string PCustNum,
			int? PCheckNum,
			string PPayType,
			DateTime? PInvDate);
	}
}

