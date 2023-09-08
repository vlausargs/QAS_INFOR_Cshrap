//PROJECT NAME: Data
//CLASS NAME: IConvertTimetoHTMLISOType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvertTimetoHTMLISOType
	{
		string ConvertTimetoHTMLISOTypeFn(
			int? TimeYear,
			int? TimeMonth,
			decimal? TimeDay,
			decimal? TimeHour,
			decimal? TimeMin,
			decimal? TimeSec);
	}
}

