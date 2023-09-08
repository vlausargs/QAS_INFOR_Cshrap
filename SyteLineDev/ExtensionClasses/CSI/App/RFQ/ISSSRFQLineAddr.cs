//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQLineAddr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQLineAddr
	{
		string SSSRFQLineAddrFn(
			string RfqNum,
			int? RfqLine,
			int? RfqSeq);
	}
}

