//PROJECT NAME: BusInterface
//CLASS NAME: IESBGetProdOrderKey.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface IESBGetProdOrderKey
	{
		string ESBGetProdOrderKeyFn(
			string Job,
			int? Suffix);
	}
}

