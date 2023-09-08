//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedCanAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSchedCanAdd
	{
		int? SSSFSSchedCanAddFn(
			string PartnerId);
	}
}

