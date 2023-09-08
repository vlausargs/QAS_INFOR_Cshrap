//PROJECT NAME: Finance
//CLASS NAME: IGetNextCheckNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetNextCheckNumber
	{
		(int? ReturnCode, int? NextCheckNumber) GetNextCheckNumberSp(string BankCode,
		string PayType,
		int? NextCheckNumber);
	}
}

