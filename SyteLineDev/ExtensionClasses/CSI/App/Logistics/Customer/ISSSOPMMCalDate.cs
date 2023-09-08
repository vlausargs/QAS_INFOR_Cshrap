//PROJECT NAME: Logistics
//CLASS NAME: ISSSOPMMCalDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSOPMMCalDate
	{
		(int? ReturnCode,
			DateTime? TJobDate) SSSOPMMCalDateSp(
			int? LeadTime,
			DateTime? TJobDate);
	}
}

