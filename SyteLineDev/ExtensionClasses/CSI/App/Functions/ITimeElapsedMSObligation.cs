//PROJECT NAME: Data
//CLASS NAME: ITimeElapsedMSObligation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITimeElapsedMSObligation
	{
		int? TimeElapsedMSObligationSp(
			string ProjNum,
			int? ProjTaskNum,
			decimal? Sequence);
	}
}

