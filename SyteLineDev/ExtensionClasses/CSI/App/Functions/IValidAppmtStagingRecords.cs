//PROJECT NAME: Data
//CLASS NAME: IValidAppmtStagingRecords.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidAppmtStagingRecords
	{
		ICollectionLoadResponse ValidAppmtStagingRecordsFn(
			Guid? PProcessId,
			string PStartingVendNum,
			string PEndingVendNum,
			string PStartingVendName,
			string PEndingVendName,
			string PSortNameNum);
	}
}

