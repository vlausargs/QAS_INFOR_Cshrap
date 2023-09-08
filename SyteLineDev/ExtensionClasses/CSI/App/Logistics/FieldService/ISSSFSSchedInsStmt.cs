//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedInsStmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSchedInsStmt
	{
		string SSSFSSchedInsStmtFn(
			Guid? RowPointer);
	}
}

