//PROJECT NAME: Data
//CLASS NAME: IHasCoShipped.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHasCoShipped
	{
		int? HasCoShippedFn(
			string CoNum);
	}
}

