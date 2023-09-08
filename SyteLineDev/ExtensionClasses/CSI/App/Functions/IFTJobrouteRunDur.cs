//PROJECT NAME: Data
//CLASS NAME: IFTJobrouteRunDur.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTJobrouteRunDur
	{
		decimal? FTJobrouteRunDurFn(
			string Job,
			int? Suffix,
			int? OperNum,
			decimal? Efficiency);
	}
}

