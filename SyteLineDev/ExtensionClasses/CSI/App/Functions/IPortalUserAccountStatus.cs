//PROJECT NAME: Data
//CLASS NAME: IPortalUserAccountStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPortalUserAccountStatus
	{
		int? PortalUserAccountStatusFn(
			string Username,
			string Portal);
	}
}

