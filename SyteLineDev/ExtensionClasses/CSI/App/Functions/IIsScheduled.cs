//PROJECT NAME: Data
//CLASS NAME: IIsScheduled.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsScheduled
	{
		int? IsScheduledFn(
			string pJob,
			int? pSuffix);
	}
}

