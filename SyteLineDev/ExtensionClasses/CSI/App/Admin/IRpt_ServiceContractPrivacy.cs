//PROJECT NAME: Admin
//CLASS NAME: IRpt_ServiceContractPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_ServiceContractPrivacy
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_ServiceContractPrivacySp(
			string CustNum,
			int? CustSeq,
			string pSite);
	}
}

