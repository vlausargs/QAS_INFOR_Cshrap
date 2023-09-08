//PROJECT NAME: Logistics
//CLASS NAME: IValidateToBeShippedRecord.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateToBeShippedRecord
	{
		(int? ReturnCode, int? pResult,
		string pDoNum) ValidateToBeShippedRecordSP(int? pBatchID = null,
		int? pResult = null,
		string pDoNum = null);
	}
}

