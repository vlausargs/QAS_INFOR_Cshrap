//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConfigParentUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConfigParentUnit
	{
		string SSSFSConfigParentUnitFn(
			string Type,
			int? CompId);
	}
}

