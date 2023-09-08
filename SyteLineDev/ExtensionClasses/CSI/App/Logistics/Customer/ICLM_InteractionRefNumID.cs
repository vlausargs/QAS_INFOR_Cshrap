//PROJECT NAME: Logistics
//CLASS NAME: ICLM_InteractionRefNumID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_InteractionRefNumID
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_InteractionRefNumIDSp(string InteractionRefType,
		string VendNum,
		int? FromPortal);
	}
}

