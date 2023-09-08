//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBShipmentHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBShipmentHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBShipmentHeaderSp(string RefType,
		string DocumentID,
		int? Status,
		string FromSite,
		string WareHouse);
	}
}

