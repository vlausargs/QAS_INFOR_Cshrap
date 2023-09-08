//PROJECT NAME: Codes
//CLASS NAME: IPortalCSICompatabilityCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IPortalCSICompatabilityCheck
	{
		(int? ReturnCode, int? ConfigIsValid,
		string ReturnMessage) PortalCSICompatabilityCheckSp(string ExpectedCSIVersion,
		string RequiredAPARs,
		int? ConfigIsValid = 0,
		string ReturnMessage = null);
	}
}

