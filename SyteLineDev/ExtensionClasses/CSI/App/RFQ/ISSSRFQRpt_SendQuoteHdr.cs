//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQRpt_SendQuoteHdr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQRpt_SendQuoteHdr
	{
		(int? ReturnCode,
			string OurContact,
			string OurPhone,
			string OurAddr,
			string OurFaxNum,
			string Infobar) SSSRFQRpt_SendQuoteHdrSp(
			string RfqNum,
			string OurContact,
			string OurPhone,
			string OurAddr,
			string OurFaxNum,
			string Infobar);
	}
}

