//PROJECT NAME: Data
//CLASS NAME: IMaterialAvailabilityEst08b.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMaterialAvailabilityEst08b
	{
		(int? ReturnCode,
			int? priorposition,
			int? PhCnt) MaterialAvailabilityEst08bSp(
			int? priorposition,
			string PhItem,
			DateTime? PhDate,
			string PhTreeString,
			decimal? PhRequired,
			int? PhCnt,
			Guid? CurSumId);
	}
}

