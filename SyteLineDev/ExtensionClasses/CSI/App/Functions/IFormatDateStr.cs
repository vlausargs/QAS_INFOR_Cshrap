//PROJECT NAME: Data
//CLASS NAME: IFormatDateStr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatDateStr
	{
		string FormatDateStrFn(
			string InputDateStr,
			string DateFormat);
	}
}

