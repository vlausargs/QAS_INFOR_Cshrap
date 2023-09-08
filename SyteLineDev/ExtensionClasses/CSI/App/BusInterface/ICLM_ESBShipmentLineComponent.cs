//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBShipmentLineComponent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBShipmentLineComponent
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBShipmentLineComponentSp(string KitItem);
	}
}

