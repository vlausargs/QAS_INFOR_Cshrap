//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetIQCDerPriority.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetIQCDerPriority
	{
		int? SSSFSGetIQCDerPriorityFn(
			string SerNum,
			DateTime? AsOfDate,
			DateTime? IncDate,
			string PriorCode,
			DateTime? DueDate);
	}
}

