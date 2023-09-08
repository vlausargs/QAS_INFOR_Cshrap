//PROJECT NAME: Data
//CLASS NAME: IMaterialAvailabilitySupDem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMaterialAvailabilitySupDem
	{
		(int? ReturnCode,
			decimal? ReqQty,
			decimal? CurrentQty) MaterialAvailabilitySupDemSp(
			string PItem,
			string PWhse,
			string PJob,
			int? PSuffix,
			decimal? HrsPerDay,
			DateTime? ReqDate,
			decimal? ReqQty,
			DateTime? CurrentDate,
			decimal? CurrentQty);
	}
}

