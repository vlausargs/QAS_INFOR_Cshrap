//PROJECT NAME: Data
//CLASS NAME: IRepCoCreditHold.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepCoCreditHold
	{
		(int? ReturnCode,
			string Infobar) RepCoCreditHoldSp(
			string pDestSite,
			string pCoNum,
			int? pCreditHold = null,
			string pCreditHoldReason = null,
			string pCreditHoldUser = null,
			DateTime? pCreditHoldDate = null,
			string Infobar = null);
	}
}

