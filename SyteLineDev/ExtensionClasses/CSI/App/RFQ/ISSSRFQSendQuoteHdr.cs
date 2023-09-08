//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQSendQuoteHdr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQSendQuoteHdr
	{
		(int? ReturnCode,
			string Profile,
			string Hdr,
			string AttList,
			string Infobar) SSSRFQSendQuoteHdrSp(
			string RfqNum,
			int? RfqLine,
			string Profile,
			string Hdr,
			string AttList,
			string Infobar);
	}
}

