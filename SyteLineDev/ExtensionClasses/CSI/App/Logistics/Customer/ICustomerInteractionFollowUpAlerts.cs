//PROJECT NAME: Data
//CLASS NAME: ICustomerInteractionFollowUpAlerts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerInteractionFollowUpAlerts
	{
		(int? ReturnCode,
			string Infobar) CustomerInteractionFollowUpAlertsSp(
			string Infobar);
	}
}

