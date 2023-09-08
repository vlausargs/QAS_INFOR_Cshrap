//PROJECT NAME: Finance
//CLASS NAME: IRevalue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IRevalue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RevalueSp(int? PPostTransactions,
		string BBankCode,
		string EBankCode,
		decimal? PUserID,
		string UseType = null,
		int? UseCheckNum = null,
		decimal? UseExchangeRate = null);
	}
}

