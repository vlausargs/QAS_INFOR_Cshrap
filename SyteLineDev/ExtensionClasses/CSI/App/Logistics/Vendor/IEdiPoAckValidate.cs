//PROJECT NAME: Logistics
//CLASS NAME: IEdiPoAckValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IEdiPoAckValidate
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) EdiPoAckValidateSp(string PoNum,
		int? SeqNum,
		string VendNum,
		int? TPost = 0,
		string Infobar = null,
		string FilterString = null);
	}
}

