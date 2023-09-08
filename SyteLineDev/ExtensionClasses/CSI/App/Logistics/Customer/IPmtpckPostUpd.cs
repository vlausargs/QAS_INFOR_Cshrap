//PROJECT NAME: Logistics
//CLASS NAME: IPmtpckPostUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPmtpckPostUpd
	{
		int? PmtpckPostUpdSp(Guid? PProcessId);
	}
}

