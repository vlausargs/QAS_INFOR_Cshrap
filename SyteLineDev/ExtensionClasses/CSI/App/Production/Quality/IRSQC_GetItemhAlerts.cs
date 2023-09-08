//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetItemhAlerts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetItemhAlerts
	{
		(int? ReturnCode, string Messages,
		string Infobar) RSQC_GetItemhAlertsSp(string RcvrNum,
		string Messages,
		string Infobar);
	}
}

