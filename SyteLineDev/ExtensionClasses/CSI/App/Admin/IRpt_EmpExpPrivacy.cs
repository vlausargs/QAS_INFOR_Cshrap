//PROJECT NAME: Admin
//CLASS NAME: IRpt_EmpExpPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_EmpExpPrivacy
	{
			(ICollectionLoadResponse Data,
			int? ReturnCode) 
		Rpt_EmpExpPrivacySp(
			string ApplicantNum = null,
			string EmpNum = null,
			string pSite = null);
	}
}

