//PROJECT NAME: Data
//CLASS NAME: IInValidPrtrxStagingRecords.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInValidPrtrxStagingRecords
	{
		int? InValidPrtrxStagingRecordsFn(
			Guid? pProcessId,
			Guid? pRowPointer,
			string pStartDept,
			string pEndDept,
			string pStartEmpNum,
			string pEndEmpNum,
			int? pPrintZeroChecks,
			string pEmpType,
			string PStartEmpCate,
			string PEndEmpCate);
	}
}

