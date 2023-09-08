//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetContPriceBasis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetContPriceBasis
	{
		string SSSFSGetContPriceBasisFn(
			string Contract,
			string Item,
			string UnitOfRate = null);
	}
}

