//PROJECT NAME: Finance
//CLASS NAME: ICLM_GetTranNumForBankReconciliations.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_GetTranNumForBankReconciliations
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetTranNumForBankReconciliationsSp(string BankReconciliationType);
	}
}

