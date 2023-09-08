//PROJECT NAME: Finance
//CLASS NAME: ICHSGetListOfAccts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetListOfAccts
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CHSGetListOfAcctsSp(string TypeCode,
		decimal? DebitAmount,
		decimal? CreditAmount,
		string Infobar);
	}
}

