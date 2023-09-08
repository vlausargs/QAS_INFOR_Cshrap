//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConfigIsUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConfigIsUnit
	{
		int? SSSFSConfigIsUnitFn(
			int? iCompID);
	}
}

