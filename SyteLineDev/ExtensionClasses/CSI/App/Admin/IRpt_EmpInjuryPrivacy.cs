//PROJECT NAME: Admin
//CLASS NAME: IRpt_EmpInjuryPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_EmpInjuryPrivacy
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_EmpInjuryPrivacySp(
			string EmpNum,
			string pSite);
	}
}

