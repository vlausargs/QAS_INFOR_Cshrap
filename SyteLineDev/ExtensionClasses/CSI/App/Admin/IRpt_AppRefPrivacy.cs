//PROJECT NAME: Admin
//CLASS NAME: IRpt_AppRefPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_AppRefPrivacy
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_AppRefPrivacySp(
			string ApplicantNum,
			string pSite);
	}
}

