//PROJECT NAME: DataCollection
//CLASS NAME: IDcsfcLotSerV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcsfcLotSerV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar,
			string NewLot) DcsfcLotSerVSp(
			string PWhse,
			string PItem,
			string PLoc,
			string PLot,
			decimal? PQty,
			int? PIssue,
			int? PItemLotTracked,
			int? PItemSerialTracked,
			int? POverride,
			int? CanOverride,
			string Infobar,
			string NewLot = null);
	}
}

