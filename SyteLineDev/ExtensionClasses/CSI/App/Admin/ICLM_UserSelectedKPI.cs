//PROJECT NAME: Admin
//CLASS NAME: ICLM_UserSelectedKPI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_UserSelectedKPI
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_UserSelectedKPISp(string ExtMsgType = null,
		int? FilterUnselected = 0);
	}
}

