//PROJECT NAME: Data
//CLASS NAME: IJmatlTm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJmatlTm
	{
		int? JmatlTmSp(
			Guid? JobmatlRowPointer,
			string MatlItem,
			string JobJob,
			int? JobSuffix,
			decimal? Qty,
			string OrderType,
			decimal? GrossQty);
	}
}

