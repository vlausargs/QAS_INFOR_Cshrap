//PROJECT NAME: BusInterface
//CLASS NAME: IESBGetProdOrderKeyInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface IESBGetProdOrderKeyInfo
	{
		ICollectionLoadResponse ESBGetProdOrderKeyInfoFn(
			string ProdOrderKey);
	}
}

