//PROJECT NAME: Logistics
//CLASS NAME: ITaxDistInsert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITaxDistInsert
	{
		(int? ReturnCode, string Infobar) TaxDistInsertSp(string PCoNum,
		int? PSeq,
		int? PTaxSystem,
		string PTaxCode,
		string PTaxCodeE,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string PTaxJur,
		decimal? PTaxRate,
		decimal? PTaxAmount,
		decimal? PTaxBasis,
		string Infobar);
	}
}

