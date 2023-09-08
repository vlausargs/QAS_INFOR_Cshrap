//PROJECT NAME: Finance
//CLASS NAME: ICashReceiptsDue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICashReceiptsDue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CashReceiptsDueSp(
			int? TransDomCurr = null,
			string StartCustNum = null,
			string EndCustNum = null,
			string SiteName = null);
	}
}

