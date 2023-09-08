//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_PastDueDatePOCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_PastDueDatePOCount
	{
			(int? ReturnCode,
			int? PastDueDatePOCount,
			int? NotPastDueDatePOCount,
			decimal? PastDueDatePOAmount,
			decimal? NotPastDueDatePOAmount) 
		Homepage_PastDueDatePOCountSp(int? PastDueDatePOCount,
			int? NotPastDueDatePOCount,
			decimal? PastDueDatePOAmount,
			decimal? NotPastDueDatePOAmount);
	}
}

