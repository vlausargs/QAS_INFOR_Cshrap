//PROJECT NAME: Data
//CLASS NAME: IFTCalculateJobShrinkFactor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTCalculateJobShrinkFactor
	{
		decimal? FTCalculateJobShrinkFactorFn(
			string Item,
			string Job,
			int? JobSuffix);
	}
}

