//PROJECT NAME: Logistics
//CLASS NAME: IWirePostCreateTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IWirePostCreateTT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) WirePostCreateTTSp(string PBegVendNum,
		string PEndVendNum,
		string PBegName,
		string PEndName,
		string PBankCode,
		string PAppmtPayType,
		DateTime? PPayDateStarting,
		DateTime? PPayDateEnding,
		Guid? PSessionID,
		string PSortNameNum = "Number");
	}
}

