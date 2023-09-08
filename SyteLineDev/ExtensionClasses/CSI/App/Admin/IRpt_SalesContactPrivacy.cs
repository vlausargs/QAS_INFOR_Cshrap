//PROJECT NAME: Admin
//CLASS NAME: IRpt_SalesContactPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_SalesContactPrivacy
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalesContactPrivacySp(Guid? SessionID,
		string pSite);
	}
}

