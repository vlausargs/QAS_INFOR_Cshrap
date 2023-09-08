//PROJECT NAME: Data
//CLASS NAME: ILateOrderShippingAlerts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILateOrderShippingAlerts
	{
		(int? ReturnCode,
			string Infobar) LateOrderShippingAlertsSp(
			string Infobar);
	}
}

