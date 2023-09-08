//PROJECT NAME: Admin
//CLASS NAME: IRpt_DropShipToPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_DropShipToPrivacy
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_DropShipToPrivacySp(Guid? SessionID,
		string pSite);
	}
}

