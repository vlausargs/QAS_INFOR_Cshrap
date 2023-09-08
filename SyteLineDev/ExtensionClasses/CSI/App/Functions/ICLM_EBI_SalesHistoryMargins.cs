//PROJECT NAME: Data
//CLASS NAME: ICLM_EBI_SalesHistoryMargins.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_EBI_SalesHistoryMargins
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_EBI_SalesHistoryMarginsSp(
			string View,
			string Site,
			DateTime? DateStarting,
			DateTime? DateEnding,
			string CustNum,
			string CustSeq,
			string Item);
	}
}

