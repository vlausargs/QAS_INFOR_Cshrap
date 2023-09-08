//PROJECT NAME: Admin
//CLASS NAME: IRpt_VendorPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_VendorPrivacy
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VendorPrivacySp(Guid? SessionID,
		string pSite);
	}
}

