//PROJECT NAME: Production
//CLASS NAME: IRSQC_PrintReceiptTag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_PrintReceiptTag
	{
		int? RSQC_PrintReceiptTagsp(int? i_RcvrNum,
		DateTime? i_TransDate,
		string i_UserCode,
		decimal? i_TagQty,
		string i_Stat);
	}
}

