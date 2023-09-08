//PROJECT NAME: Admin
//CLASS NAME: IRpt_PointOfSalesPrivacy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRpt_PointOfSalesPrivacy
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_PointOfSalesPrivacySp(
			string CustNum,
			int? CustSeq,
			string pSite);
	}
}

