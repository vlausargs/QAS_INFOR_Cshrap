//PROJECT NAME: Admin
//CLASS NAME: IRpt_PartnerPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_PartnerPrivacy
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PartnerPrivacySp(string RefNum,
		int? RefSeq,
		string RefType,
		string pSite);
	}
}

