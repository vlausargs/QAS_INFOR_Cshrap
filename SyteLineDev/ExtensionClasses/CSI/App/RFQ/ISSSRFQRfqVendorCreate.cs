//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQRfqVendorCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQRfqVendorCreate
	{
		(int? ReturnCode,
			string Infobar) SSSRFQRfqVendorCreateSp(
			string RfqNum,
			int? RfqLine,
			Guid? SessionID,
			string Infobar);
	}
}

