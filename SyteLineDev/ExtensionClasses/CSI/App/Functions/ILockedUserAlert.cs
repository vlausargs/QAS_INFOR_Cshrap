//PROJECT NAME: Data
//CLASS NAME: ILockedUserAlert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILockedUserAlert
	{
		(int? ReturnCode,
			string Infobar) LockedUserAlertSp(
			string Username,
			string WhereToExecute,
			string Infobar);
	}
}

