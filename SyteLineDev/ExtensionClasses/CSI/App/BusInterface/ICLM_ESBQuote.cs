//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBQuote.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBQuote
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBQuoteSp(string DocumentID,
		string DocumentIDNum);
	}
}

