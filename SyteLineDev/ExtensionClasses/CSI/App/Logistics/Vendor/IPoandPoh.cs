//PROJECT NAME: Logistics
//CLASS NAME: IPoandPoh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoandPoh
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PoandPohSp();
	}
}

