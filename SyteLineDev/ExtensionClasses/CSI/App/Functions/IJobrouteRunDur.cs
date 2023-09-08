//PROJECT NAME: Data
//CLASS NAME: IJobrouteRunDur.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobrouteRunDur
	{
		decimal? JobrouteRunDurFn(
			string Job,
			int? Suffix,
			int? OperNum,
			decimal? Efficiency);
	}
}

