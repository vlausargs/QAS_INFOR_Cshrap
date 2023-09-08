//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MassJP_Msg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MassJP_Msg
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MassJP_MsgSp(string SessionIdChar = null,
		string pSite = null);
	}
}

