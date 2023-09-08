//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedLabelsInsertRecord.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSchedLabelsInsertRecord
	{
		int? SSSFSSchedLabelsInsertRecordSp(
			string UserName,
			string SechID,
			string SubType);
	}
}

