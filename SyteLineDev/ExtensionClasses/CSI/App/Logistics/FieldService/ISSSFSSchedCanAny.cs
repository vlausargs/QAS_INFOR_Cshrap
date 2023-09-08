//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedCanAny.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSchedCanAny
	{
		int? SSSFSSchedCanAnyFn(
			string Permission,
			string PartnerId);
	}
}

