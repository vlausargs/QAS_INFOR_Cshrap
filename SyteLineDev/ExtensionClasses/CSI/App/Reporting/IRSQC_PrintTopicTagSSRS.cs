//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_PrintTopicTagSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_PrintTopicTagSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_PrintTopicTagSSRSsp(int? i_RcvrNum,
		decimal? i_TagQty,
		string psite);
	}
}

