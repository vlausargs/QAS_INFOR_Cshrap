//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQRFQCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQRFQCreate
	{
		(int? ReturnCode,
			string Infobar) SSSRFQRFQCreateSp(
			string RollupMethod,
			string AppendRfqNum,
			string PSessionId,
			string Infobar);
	}
}

