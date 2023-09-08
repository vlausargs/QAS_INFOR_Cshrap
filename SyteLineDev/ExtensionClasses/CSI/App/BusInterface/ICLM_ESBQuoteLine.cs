//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBQuoteLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBQuoteLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBQuoteLineSp(string DocumentID,
		string DocumentIDNum);
	}
}

