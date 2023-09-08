//PROJECT NAME: Material
//CLASS NAME: IMrpOrderActionStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpOrderActionStartDate
	{
		DateTime? MrpOrderActionStartDateFn(
			DateTime? XStartDate,
			int? LeadTime);
	}
}

