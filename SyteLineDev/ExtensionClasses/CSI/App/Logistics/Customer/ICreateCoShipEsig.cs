//PROJECT NAME: Logistics
//CLASS NAME: ICreateCoShipEsig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICreateCoShipEsig
	{
		int? CreateCoShipEsigSp(
			Guid? TmpShipRowpointer,
			int? TmpShipSequence);
	}
}

