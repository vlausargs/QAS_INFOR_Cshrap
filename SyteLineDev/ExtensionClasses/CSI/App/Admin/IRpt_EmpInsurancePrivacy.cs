//PROJECT NAME: Admin
//CLASS NAME: IRpt_EmpInsurancePrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_EmpInsurancePrivacy
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_EmpInsurancePrivacySp(
			string EmpNum,
			string pSite);
	}
}

