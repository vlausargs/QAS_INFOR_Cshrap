//PROJECT NAME: Logistics
//CLASS NAME: IARPaymentPostingCleanup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARPaymentPostingCleanup
	{
		(int? ReturnCode, string Infobar) ARPaymentPostingCleanupSp(Guid? PProcessID,
		string Infobar);
	}
}

