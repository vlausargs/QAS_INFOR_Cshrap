//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXDispRwrkPre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXDispRwrkPre
	{
		(int? ReturnCode,
			string Infobar) SSSRMXDispRwrkPreSp(
			Guid? DispRowPointer,
			string Infobar);
	}
}

