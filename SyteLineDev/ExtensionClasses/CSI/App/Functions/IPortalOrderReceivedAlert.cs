//PROJECT NAME: Data
//CLASS NAME: IPortalOrderReceivedAlert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPortalOrderReceivedAlert
	{
		(int? ReturnCode,
			string Infobar) PortalOrderReceivedAlertSp(
			string CustNum,
			string CoNum,
			string Infobar);
	}
}

