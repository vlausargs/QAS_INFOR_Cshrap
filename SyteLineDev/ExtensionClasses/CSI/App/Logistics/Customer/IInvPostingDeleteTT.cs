//PROJECT NAME: Logistics
//CLASS NAME: IInvPostingDeleteTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvPostingDeleteTT
	{
		int? InvPostingDeleteTTSp(Guid? PSessionID);
	}
}

