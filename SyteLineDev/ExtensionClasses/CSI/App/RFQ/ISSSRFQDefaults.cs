//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQDefaults.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQDefaults
	{
		(int? ReturnCode, string Buyer,
		DateTime? ReplyDate,
		string Infobar) SSSRFQDefaultsSp(string Buyer,
		DateTime? ReplyDate,
		string Infobar);
	}
}

