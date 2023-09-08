//PROJECT NAME: Admin
//CLASS NAME: IRpt_EmpPrBankPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_EmpPrBankPrivacy
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EmpPrBankPrivacySp(string EmpNum, string pSite);
	}
}

