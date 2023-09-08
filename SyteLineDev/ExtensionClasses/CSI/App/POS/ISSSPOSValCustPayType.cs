//PROJECT NAME: POS
//CLASS NAME: ISSSPOSValCustPayType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSValCustPayType
	{
		(int? ReturnCode,
			int? IsValid) SSSPOSValCustPayTypeSp(
			string CustNum = null,
			string PayType = null,
			int? IsValid = null);
	}
}

