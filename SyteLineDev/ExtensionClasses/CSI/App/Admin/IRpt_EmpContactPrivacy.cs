//PROJECT NAME: Admin
//CLASS NAME: IRpt_EmpContactPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_EmpContactPrivacy
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_EmpContactPrivacySp(
			string EmpNum,
			string pSite);
	}
}

