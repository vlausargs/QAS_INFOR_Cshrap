//PROJECT NAME: Admin
//CLASS NAME: IRpt_ApplicantPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_ApplicantPrivacy
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ApplicantPrivacySp(Guid? SessionID,
		string pSite);
	}
}

