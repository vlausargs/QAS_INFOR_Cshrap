//PROJECT NAME: Production
//CLASS NAME: IProjTaskCalcTotals.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjTaskCalcTotals
	{
		decimal? ProjTaskCalcTotalsFn(
			string CalcType,
			string ProjNum,
			int? TaskNum,
			int? Seq,
			string CostCodeType,
			decimal? OvhRate,
			decimal? GARate,
			string type);
	}
}

