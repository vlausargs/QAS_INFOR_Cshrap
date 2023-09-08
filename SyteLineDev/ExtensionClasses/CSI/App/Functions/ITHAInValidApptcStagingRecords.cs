//PROJECT NAME: Data
//CLASS NAME: ITHAInValidApptcStagingRecords.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAInValidApptcStagingRecords
	{
		int? THAInValidApptcStagingRecordsFn(
			Guid? PProcessId,
			Guid? RowPointer,
			string PStartingVendNum,
			string PEndingVendNum,
			string PStartingVendName,
			string PEndingVendName,
			string PSortNameNum,
			DateTime? PPayDateStarting,
			DateTime? PPayDateEnding);
	}
}

