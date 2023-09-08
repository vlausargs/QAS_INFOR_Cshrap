//PROJECT NAME: Finance
//CLASS NAME: IUpdateCurrentPeriodDepreciationToZero.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IUpdateCurrentPeriodDepreciationToZero
	{
		(int? ReturnCode, int? pNeedToUpdateCurPerDepr) UpdateCurrentPeriodDepreciationToZeroSp(string pFaNum,
		int? pNeedToUpdateCurPerDepr);
	}
}

