//PROJECT NAME: Admin
//CLASS NAME: IRpt_EmpEducationPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_EmpEducationPrivacy
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_EmpEducationPrivacySp(
			string ApplicantNum = null,
			string EmpNum = null,
			string pSite = null);
	}
}

