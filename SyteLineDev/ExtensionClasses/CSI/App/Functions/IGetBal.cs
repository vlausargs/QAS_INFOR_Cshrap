//PROJECT NAME: Data
//CLASS NAME: IGetBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetBal
	{
		decimal? GetBalFn(
			string Item,
			DateTime? TransDate,
			int? IncludeNonNetStk,
			string WhseStarting,
			string WhseEnding,
			string LocStarting,
			string LocEnding,
			string ReasonCodeStarting,
			string ReasonCodeEnding,
			int? AllWhse,
			int? AllLoc,
			int? AllReasonCode,
			decimal? TransNum);
	}
}

