//PROJECT NAME: Finance
//CLASS NAME: IGetNextReconciliationTypeNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetNextReconciliationTypeNum
	{
		(int? ReturnCode, int? NextCheckNumber) GetNextReconciliationTypeNumSp(string BankCode,
		string PayType,
		int? NextCheckNumber);
	}
}

