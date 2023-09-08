//PROJECT NAME: Production
//CLASS NAME: ICalculateJobShrinkFactor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICalculateJobShrinkFactor
	{
		decimal? CalculateJobShrinkFactorFn(
			string Item,
			string Job,
			int? JobSuffix);
	}
}

