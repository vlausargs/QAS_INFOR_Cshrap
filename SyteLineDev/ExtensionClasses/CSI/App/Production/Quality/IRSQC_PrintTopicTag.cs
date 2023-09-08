//PROJECT NAME: Production
//CLASS NAME: IRSQC_PrintTopicTag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_PrintTopicTag
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_PrintTopicTagsp(
			int? i_RcvrNum,
			decimal? i_TagQty);
	}
}

