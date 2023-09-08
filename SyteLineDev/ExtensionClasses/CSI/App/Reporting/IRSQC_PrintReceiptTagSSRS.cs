//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_PrintReceiptTagSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_PrintReceiptTagSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_PrintReceiptTagSSRSsp(int? i_RcvrNum,
		DateTime? i_TransDate,
		string i_UserCode,
		decimal? i_TagQty,
		string i_Stat,
		string psite);
	}
}

