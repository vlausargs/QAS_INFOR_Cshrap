//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSFormatEscalationFrequency.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSFormatEscalationFrequency
	{
		string SSSFSFormatEscalationFrequencyFn(
			Guid? RowPointer,
			string Table = "E");
	}
}

