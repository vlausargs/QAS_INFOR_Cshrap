//PROJECT NAME: Codes
//CLASS NAME: IAlertNotifyTaskBODDistributionPersonId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IAlertNotifyTaskBODDistributionPersonId
	{
		(int? ReturnCode, string DistributionPersonId) AlertNotifyTaskBODDistributionPersonIdSp(string Username,
		string DistributionPersonId);
	}
}

