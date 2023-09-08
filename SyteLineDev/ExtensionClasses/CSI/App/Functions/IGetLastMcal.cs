//PROJECT NAME: Data
//CLASS NAME: IGetLastMcal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetLastMcal
	{
		DateTime? GetLastMcalFn();
	}
}

