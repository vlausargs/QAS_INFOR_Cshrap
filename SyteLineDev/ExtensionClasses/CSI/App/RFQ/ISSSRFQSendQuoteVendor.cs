//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQSendQuoteVendor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQSendQuoteVendor
	{
		(int? ReturnCode,
			string Infobar) SSSRFQSendQuoteVendorSp(
			string RfqNum,
			int? RfqLine,
			int? RfqSeq,
			string Infobar);
	}
}

