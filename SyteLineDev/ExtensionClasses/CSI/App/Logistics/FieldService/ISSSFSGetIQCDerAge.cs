//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetIQCDerAge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetIQCDerAge
	{
		int? SSSFSGetIQCDerAgeFn(
			DateTime? AsOfDate,
			DateTime? IncDate);
	}
}

