//PROJECT NAME: Data
//CLASS NAME: IFeatureActivationDueAlert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFeatureActivationDueAlert
	{
		(int? ReturnCode,
			string Infobar) FeatureActivationDueAlertSp(
			string Infobar);
	}
}

