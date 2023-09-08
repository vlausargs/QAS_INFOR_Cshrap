//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQSendQuoteLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQSendQuoteLine
	{
		int? SSSRFQSendQuoteLineSp(
			string RfqNum,
			int? RfqLine,
			int? RfqSeq,
			int? Preview);
	}
}

