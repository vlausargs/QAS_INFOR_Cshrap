//PROJECT NAME: Data
//CLASS NAME: IProspectInteractionFollowUpAlerts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProspectInteractionFollowUpAlerts
	{
		(int? ReturnCode,
			string Infobar) ProspectInteractionFollowUpAlertsSp(
			string Infobar);
	}
}

