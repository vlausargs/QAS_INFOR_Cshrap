//PROJECT NAME: Admin
//CLASS NAME: IRpt_CreditCardPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_CreditCardPrivacy
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_CreditCardPrivacySp(
			string CustNum,
			int? CustSeq,
			string pSite);
	}
}

