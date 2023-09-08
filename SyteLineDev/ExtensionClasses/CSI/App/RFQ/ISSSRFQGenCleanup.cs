//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQGenCleanup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQGenCleanup
	{
		int? SSSRFQGenCleanupSp(string PSessionId);
	}
}

