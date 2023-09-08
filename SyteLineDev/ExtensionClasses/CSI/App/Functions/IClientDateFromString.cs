//PROJECT NAME: Data
//CLASS NAME: IClientDateFromString.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IClientDateFromString
	{
		DateTime? ClientDateFromStringFn(
			string Date);
	}
}

