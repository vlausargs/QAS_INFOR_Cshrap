//PROJECT NAME: Admin
//CLASS NAME: IRpt_ServiceContactPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_ServiceContactPrivacy
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_ServiceContactPrivacySp(
			string CustNum,
			int? CustSeq,
			string pSite);
	}
}

