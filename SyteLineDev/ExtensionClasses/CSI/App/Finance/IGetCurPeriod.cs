//PROJECT NAME: Finance
//CLASS NAME: IGetCurPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetCurPeriod
	{
		(int? ReturnCode, int? pCurPeriod) GetCurPeriodSp(int? pCurPeriod);

		int? GetCurPeriodFn();
	}
}

