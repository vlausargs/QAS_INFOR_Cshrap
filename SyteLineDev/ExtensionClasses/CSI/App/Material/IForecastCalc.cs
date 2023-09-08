//PROJECT NAME: Material
//CLASS NAME: IForecastCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IForecastCalc
	{
		int? ForecastCalcSp(string Item);
	}
}

