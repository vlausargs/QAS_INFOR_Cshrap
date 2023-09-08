//PROJECT NAME: Data
//CLASS NAME: IFormatFeatStr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatFeatStr
	{
		string FormatFeatStrFn(
			string pFeatStr,
			string pFeatTempl);
	}
}

