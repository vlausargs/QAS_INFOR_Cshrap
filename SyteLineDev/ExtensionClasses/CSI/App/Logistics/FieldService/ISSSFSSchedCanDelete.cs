//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedCanDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSchedCanDelete
	{
		int? SSSFSSchedCanDeleteFn(
			string PartnerId);
	}
}

