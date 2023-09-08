//PROJECT NAME: Data
//CLASS NAME: IFormatDecimalAsString.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatDecimalAsString
	{
		string FormatDecimalAsStringFn(
			decimal? DecimalAmount,
			int? DecimalPlaces);
	}
}

