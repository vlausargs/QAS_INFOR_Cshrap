//PROJECT NAME: Logistics
//CLASS NAME: IProfilePackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IProfilePackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfilePackingSlipSp(string CustNum,
		int? CustSeq);
	}
}

