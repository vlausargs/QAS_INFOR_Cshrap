//PROJECT NAME: Data
//CLASS NAME: IIntraSiteTransferSupDem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIntraSiteTransferSupDem
	{
		ICollectionLoadResponse IntraSiteTransferSupDemFn(
			string Item,
			string Whse);
	}
}

