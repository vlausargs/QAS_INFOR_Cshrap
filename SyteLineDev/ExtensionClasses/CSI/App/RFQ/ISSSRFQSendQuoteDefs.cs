//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQSendQuoteDefs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQSendQuoteDefs
	{
			(int? ReturnCode,
			string FaxMethod,
			string Infobar) 
		SSSRFQSendQuoteDefsSp(
			string FaxMethod,
			string Infobar);
	}
}

