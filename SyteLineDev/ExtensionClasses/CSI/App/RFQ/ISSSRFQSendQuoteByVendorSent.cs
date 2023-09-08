//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQSendQuoteByVendorSent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQSendQuoteByVendorSent
	{
		(int? ReturnCode, string Infobar) SSSRFQSendQuoteByVendorSentSp(string RfqNum,
		int? RfqLine,
		int? RfqSeq,
		string DistMethod,
		string Infobar);
	}
}

