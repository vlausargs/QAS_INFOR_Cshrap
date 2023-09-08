//PROJECT NAME: Data
//CLASS NAME: ICalFudgeAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalFudgeAmount
	{
		(int? ReturnCode,
			decimal? Fudge,
			int? NumLines) CalFudgeAmountSp(
			string InvNum,
			string CurrCode,
			decimal? Fudge,
			int? NumLines);
	}
}

