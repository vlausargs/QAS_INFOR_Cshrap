//PROJECT NAME: Admin
//CLASS NAME: IRpt_ProspectPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_ProspectPrivacy
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProspectPrivacySp(Guid? SessionID,
		string pSite);
	}
}

