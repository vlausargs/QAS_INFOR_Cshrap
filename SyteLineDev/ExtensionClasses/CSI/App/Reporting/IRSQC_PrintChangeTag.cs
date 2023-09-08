//PROJECT NAME: Reporting
//CLASS NAME: IRSQC_PrintChangeTag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRSQC_PrintChangeTag
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_PrintChangeTagsp(int? i_RcvrNum,
		decimal? i_TagQty,
		string psite);
	}
}

