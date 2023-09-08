//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSFormatEscalationAction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSFormatEscalationAction
	{
		string SSSFSFormatEscalationActionFn(
			Guid? RowPointer,
			string Table = "E");
	}
}

