//PROJECT NAME: Data
//CLASS NAME: IPortalOrderOnHoldCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPortalOrderOnHoldCheck
	{
		(int? ReturnCode,
			string Infobar) PortalOrderOnHoldCheckSp(
			string CoNum,
			string Infobar);
	}
}

