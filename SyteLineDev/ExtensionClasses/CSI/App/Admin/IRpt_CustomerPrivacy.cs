//PROJECT NAME: Admin
//CLASS NAME: IRpt_CustomerPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_CustomerPrivacy
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerPrivacySp(Guid? SessionID,
		string pSite);
	}
}

