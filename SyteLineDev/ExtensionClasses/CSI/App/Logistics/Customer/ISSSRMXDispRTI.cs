//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXDispRTI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXDispRTI
	{
		(int? ReturnCode,
			string Infobar) SSSRMXDispRTISp(
			Guid? DispRowPointer,
			string Infobar);
	}
}

