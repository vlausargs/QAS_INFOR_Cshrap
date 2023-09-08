//PROJECT NAME: Data
//CLASS NAME: IOrderShippingAlerts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IOrderShippingAlerts
	{
		(int? ReturnCode,
			string Infobar) OrderShippingAlertsSp(
			string Infobar);
	}
}

