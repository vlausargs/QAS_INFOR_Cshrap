//PROJECT NAME: Logistics
//CLASS NAME: IARFinChgPostDeleteTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARFinChgPostDeleteTT
	{
		int? ARFinChgPostDeleteTTSp(Guid? PSessionID);
	}
}

