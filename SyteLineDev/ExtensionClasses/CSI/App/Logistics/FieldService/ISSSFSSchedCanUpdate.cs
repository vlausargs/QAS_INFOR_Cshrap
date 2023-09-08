//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedCanUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSchedCanUpdate
	{
		int? SSSFSSchedCanUpdateFn(
			string PartnerId);
	}
}

