//PROJECT NAME: Data
//CLASS NAME: ISetDateOnly.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISetDateOnly
	{
		string SetDateOnlyFn(
			DateTime? InDate);
	}
}

