//PROJECT NAME: Admin
//CLASS NAME: IRpt_EmpChildPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_EmpChildPrivacy
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_EmpChildPrivacySp(
			string EmpNum,
			string pSite);
	}
}

