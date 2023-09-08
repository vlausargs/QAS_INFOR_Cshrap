//PROJECT NAME: Production
//CLASS NAME: IRSQC_ShowTransactions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ShowTransactions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_ShowTransactionsSp(
			int? rcvr_num,
			string i_num);
	}
}

