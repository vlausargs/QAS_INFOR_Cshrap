//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSForecastCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSForecastCalc
	{
		int? EXTSSSFSForecastCalcSp(
			string iItem,
			DateTime? iFcstDate,
			int? iTFcstAhd,
			int? iTFcstBhd);
	}
}

