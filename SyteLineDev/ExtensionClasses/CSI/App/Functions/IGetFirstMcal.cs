//PROJECT NAME: Data
//CLASS NAME: IGetFirstMcal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetFirstMcal
	{
		DateTime? GetFirstMcalFn();
	}
}

