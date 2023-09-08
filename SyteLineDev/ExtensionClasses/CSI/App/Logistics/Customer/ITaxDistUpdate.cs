//PROJECT NAME: Logistics
//CLASS NAME: ITaxDistUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITaxDistUpdate
	{
		(int? ReturnCode, string Infobar) TaxDistUpdateSp(Guid? PRowPointer,
		string PCoNum,
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

