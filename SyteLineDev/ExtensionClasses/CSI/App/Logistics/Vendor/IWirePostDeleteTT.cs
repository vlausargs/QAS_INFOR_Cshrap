//PROJECT NAME: Logistics
//CLASS NAME: IWirePostDeleteTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IWirePostDeleteTT
	{
		int? WirePostDeleteTTSp(Guid? PSessionID,
		string AppmtPayType,
		int? bRemitAdvicePrint = 0);
	}
}

