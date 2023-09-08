//PROJECT NAME: Data
//CLASS NAME: IUseForecast.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUseForecast
	{
		int? UseForecastFn(
			int? DetailDisplay);
	}
}

