//PROJECT NAME: Production
//CLASS NAME: IApsTraceMsg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsTraceMsg
	{
		int? ApsTraceMsgSp(
			string Msg,
			int? AltNo = 0);
	}
}

