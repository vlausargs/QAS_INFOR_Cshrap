//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQRpt_SendQuoteLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQRpt_SendQuoteLine
	{
		int? SSSRFQRpt_SendQuoteLineSp(
			string RfqNum,
			int? RfqLine,
			int? RfqSeq,
			string OurContact,
			string OurPhone,
			string OurAddr,
			string OurFaxNum);
	}
}

