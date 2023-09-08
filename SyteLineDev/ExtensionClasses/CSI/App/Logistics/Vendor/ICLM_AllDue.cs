//PROJECT NAME: Logistics
//CLASS NAME: ICLM_AllDue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_AllDue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_AllDueSp(string pBankCode,
		string pVendNum,
		int? pCheckSeq,
		DateTime? pCheckDate,
		int? pCheckNum,
		string FilterString = null);
	}
}

