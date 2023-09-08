//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXDispScrap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXDispScrap
	{
		(int? ReturnCode,
			string Infobar) SSSRMXDispScrapSp(
			Guid? DispRowPointer,
			string Infobar);
	}
}

