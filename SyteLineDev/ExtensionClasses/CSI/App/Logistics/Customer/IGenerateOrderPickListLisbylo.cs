//PROJECT NAME: Logistics
//CLASS NAME: IGenerateOrderPickListLisbylo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateOrderPickListLisbylo
	{
		(int? ReturnCode,
			Guid? PItemlocRowPointer,
			string PItemlocLoc,
			Guid? PLotLocRowPointer,
			string PLotLocLot,
			string Infobar) GenerateOrderPickListLisbyloSp(
			string PCoitemWhse,
			string PCoitemItem,
			int? PItemLotTracked,
			string PItemIssueBy,
			Guid? PItemlocRowPointer,
			string PItemlocLoc,
			Guid? PLotLocRowPointer,
			string PLotLocLot,
			string Infobar);
	}
}

